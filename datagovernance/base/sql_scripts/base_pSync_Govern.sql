USE [Profisee]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE SCHEMA [gov]
GO

CREATE PROCEDURE [gov].[base_pSync_Govern] 
AS

SET NOCOUNT ON 
BEGIN

DECLARE @Message varchar(255);  

----PROCESS UPDATES AND INSERTS
--Profisee Users
BEGIN TRY 
	TRUNCATE TABLE stg.tGovern_User_Merge 
	INSERT INTO stg.tGovern_User_Merge (Code, Name, User_Status, UpdatedDate, UpdatedBy, CreatedDate, CreatedBy, Email_Address, Description)
	SELECT u.UID Code, u.Name, u.StatusID User_Status, u.LastChgDTM UpdatedDate, lu.UID AS UpdatedBy, u.EnterDTM CreatedDate, eu.UID CreatedBy, u.EmailAddress, u.Description
	 FROM meta.tuser u
	 LEFT OUTER JOIN meta.tUser eu ON u.EnterUserID = eu.id
	 LEFT OUTER JOIN meta.tUser lu ON u.LastChgUserID = lu.id
	 LEFT OUTER JOIN data.tGovern_User geu ON geu.ID = IIF(u.EnterUserID = 0, u.ID, u.EnterUserID) 
	 LEFT OUTER JOIN data.tGovern_User glu ON glu.ID = IIF(u.LastChgUserID = 0, u.ID, u.LastChgUserID)
	 WHERE u.name IS NOT NULL
	EXCEPT
	SELECT gu._#UID#_ Code, gu.Name, gu.User_Status, gu.UpdatedDate, gu.Code UpdatedBy, gu.CreatedDate, gu.Code CreatedBy, gu.Email_Address, gu.Description
	 FROM data.tGovern_User gu
	WHERE gu.Name IS NOT NULL
	
	EXEC stg.pGovern_User_Merge
END TRY
 
BEGIN CATCH   
	SELECT @Message = 'Error processing USERS_MERGE governance synchronization: ' + ERROR_MESSAGE()  
 
	EXEC xp_logevent 69000, @Message, ERROR
END CATCH;  


--Profisee Entities
BEGIN TRY 
	TRUNCATE TABLE stg.tGovern_Entity_Merge 
	INSERT INTO stg.tGovern_Entity_Merge (Code, Name, Description, SQL_View, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, CodeGenerationEnabledYN, CodeGenerationSeed)
    SELECT e.UID Code, e.Name, e.Description, N'data.v' + [e].[Name] AS [SQL_View], eu.UID CreatedBy, e.EnterDTM CreatedDate, lu.UID UpdatedBy, e.LastChgDTM UpdatedDate, IIF(e.KeyGenSeed <> 0, 'Y', 'N') CodeGenerationEnabledYN, KeyGenSeed CodeGenerationSeed
   	  FROM meta.tEntity e
	  LEFT OUTER JOIN meta.tStaging c ON c.EntityId = e.ID and c.TypeId = 1
	  LEFT OUTER JOIN meta.tStaging d ON d.EntityId = e.ID and d.TypeId = 2
	  LEFT OUTER JOIN meta.tStaging m ON m.EntityId = e.ID and m.TypeId = 0
	  LEFT OUTER JOIN meta.tUser eu ON eu.ID = e.EnterUserID
	  LEFT OUTER JOIN meta.tUser lu ON lu.ID = e.LastChgUserID
	 WHERE e.Name NOT LIKE 'Govern_%'
	EXCEPT
	SELECT ge.Code, ge.Name, ge.Description, ge.SQL_View, eu.UID CreatedBy, ge.CreatedDate, lu.UID UpdatedBy, ge.UpdatedDate, mmyn.Code CodeGenerationEnabledYN, ge.CodeGenerationSeed
	 FROM data.tGovern_Entity ge
	 LEFT OUTER JOIN data.tGovern_YesNo mmyn ON mmyn.ID = ge.CodeGenerationEnabledYN 
	 LEFT OUTER JOIN meta.tUser eu ON eu.ID = ge.EnterUserID 
	 LEFT OUTER JOIN meta.tUser lu ON lu.ID = ge.LastChgUserID
 
	
	EXEC stg.pGovern_Entity_Merge
END TRY
 
BEGIN CATCH   
	SELECT @Message = 'Error processing ENTITY_MERGE governance synchronization: ' + ERROR_MESSAGE()  
 
	EXEC xp_logevent 69000, @Message, ERROR
END CATCH;  

--Profisee Attributes
BEGIN TRY 
	TRUNCATE TABLE stg.tGovern_Attribute_Merge 
	INSERT INTO stg.tGovern_Attribute_Merge (Code, Name, Description, Entity, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, Length, Precision, Domain_Entity, Data_Type, Attribute_Type, SystemYN)
	SELECT a.UID Profisee_UID, e.Name + ' : ' + a.Name Name, a.Description, e.UID Entity, eu.UID CreatedBy, a.EnterDTM CreatedDate, lu.UID UpdatedBy, a.LastChgDTM UpdatedDate, a.Length, a.Precision, de.UID Domain_Entity, DataTypeID DataType, TypeID Attribute_Type, IIF((a.IsPrimaryKey = 1 OR a.IsPrimaryName = 1), 'Y', 'N') SystemYN	
  	  FROM meta.tAttribute a
	 INNER JOIN meta.tEntity e ON e.ID = a.EntityId AND e.Name NOT LIKE 'Govern_%'
	 LEFT OUTER JOIN meta.tEntity de ON de.ID = a.DomainEntityID AND de.Name NOT LIKE 'Govern_%'
	 LEFT OUTER JOIN meta.tUser eu ON e.EnterUserID = eu.ID
	 LEFT OUTER JOIN meta.tUser lu ON e.LastChgUserID = lu.ID
	EXCEPT
	SELECT ga.code, ga.Name, ga.Description, ga._#UID#_ Entity, eu.UID CreatedBy, ga.CreatedDate, lu.UID UpdatedBy, ga.UpdatedDate, ga.Length, ga.Precision, ga._#UID#_, ga.Data_Type, ga.Attribute_Type, mmyn.Code SystemYN
 	  FROM data.tGovern_Attribute ga
	  LEFT OUTER JOIN data.tGovern_YesNo mmyn ON mmyn.ID = ga.SystemYN
	  LEFT OUTER JOIN meta.tUser eu ON ga.EnterUserID = eu.ID
	  LEFT OUTER JOIN meta.tUser lu ON ga.LastChgUserID = lu.ID
	
	EXEC stg.pGovern_Attribute_Merge
END TRY
 
BEGIN CATCH  
	SELECT @Message = 'Error processing ATTRIBUTE_MERGE governance synchronization: ' + ERROR_MESSAGE()  
 
	EXEC xp_logevent 69000, @Message, ERROR
END CATCH;  


--Profisee Attributes
BEGIN TRY
	TRUNCATE TABLE stg.tGovern_Attribute_Delete
	INSERT INTO stg.tGovern_Attribute_Delete (Code)
	SELECT mma.Code 
	  FROM data.tGovern_Attribute mma
	 WHERE mma.Code NOT IN (SELECT a.UID FROM meta.tAttribute a) 
	
    EXEC stg.pGovern_Attribute_Delete
END TRY
 
BEGIN CATCH   
	SELECT @Message = 'Error processing ATTRIBUTE_DELETE governance synchronization: ' + ERROR_MESSAGE()  
 
	EXEC xp_logevent 69000, @Message, ERROR
END CATCH;  


--Profisee Entities
BEGIN TRY 
    TRUNCATE TABLE stg.tGovern_Entity_Delete
    INSERT INTO stg.tGovern_Entity_Delete (Code)
    SELECT mme.Code 
      FROM data.tGovern_Entity mme
     WHERE mme.Code NOT IN (SELECT e.UID FROM meta.tEntity e)
    
    EXEC stg.pGovern_Entity_Delete
END TRY
 
BEGIN CATCH   
	SELECT @Message = 'Error processing ENTITY_DELETE governance synchronization: ' + ERROR_MESSAGE()  
 
	EXEC xp_logevent 69000, @Message, ERROR
END CATCH; 


--Profisee Users
BEGIN TRY
    TRUNCATE TABLE stg.tGovern_User_Delete
    INSERT INTO stg.tGovern_User_Delete (Code)
    SELECT gu.Code 
      FROM data.tGovern_User gu
     WHERE gu.Code NOT IN (SELECT u.UID FROM meta.tUser u)
    
    EXEC stg.pGovern_User_Delete
END TRY
 
BEGIN CATCH   
	SELECT @Message = 'Error processing USER_DELETE governance synchronization: ' + ERROR_MESSAGE()  
 
	EXEC xp_logevent 69000, @Message, ERROR
END CATCH;  

RETURN ISNULL(ERROR_NUMBER(), 0)

END

GO


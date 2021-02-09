# *Governance Base Template*

## Overview
The *Profisee Governance Base Template* provides a series of entities and a supporting application to manage basic master data governance activities. The template consumes 50 attributes. An extended set of entities, attributes, data quality rules, workflows, and applications will be released later in a separate GitHub repository.

### Usage
The basic governance template is designed to enable the following activities:
- Capture business definitions: glossary items
- Annotate entity and attribute definitions
- Assign business users (data stewards and owners) to individual entities and attributes
- Add user-defined governance reference data

As Profisee entities and attributes are created, updated, and deleted the installed SQL Server job periodically synchronizes the changes against the 'Govern_' entities.

## Prerequisites
- Profisee Version 2020 R2
- Profisee Platform Tools installed 2020 R2 (CLU)
- Microsoft sqlcmd utility
- Microsoft PowerShell

## Entities Included in Base Model
- Govern_Attribute
- Govern_AttributeType
- Govern_BusinessGlossary
- Govern_Entity
- Govern_User
- Govern_UserStatus
- Govern_YesNo

## Folder Structure
### profisee_objects
		-> Business Glossary.presentationview 
		-> Govern Attributes.presentationview
		-> Govern Entities.presentationview
		-> User Catalog.presentationview		
		-> Govern_Attribute_Delete.stagingtable
		-> Govern_Attribute_Merge.stagingtable
		-> Govern_AttributeType_Merge.stagingtable
		-> Govern_Entity_Delete.stagingtable
		-> Govern_Entity_Merge.stagingtable
		-> Govern_User_Delete.stagingtable
		-> Govern_User_Merge.stagingtable
		-> Govern_YesNo_Merge.stagingtable
		-> Govern_Entity.maestroform
		-> Govern_Users.maestroform
		-> Governance Reference Data.archive
		-> Governance.portalapplication
		-> Profisee.maestromodel
### sql_scripts
		-> base_jSync_Govern.sql
		-> base_pSync_Govern.sql
		-> Uninstall.sql

## Installation Procedure
### Execute Govern_install.ps1. 
    User must enter the following parameters: 
        a. Profisee service URI (example: https://corp.acme.com/profisee/api/service.svc)
        b. SQL Server host (example: localhost)
        c. Profisee database name (example: Profisee)
        d. ClientID: [clientID of service account]
	
Once all parameters are entered, the Profisee objects will be imported as well as creation of the Governance synchronization SQL stored procedure and SQL Agent job.

## Uninstall Procedure
### Execute Govern_uninstall.ps1. 
    User must enter the following parameters: 
        a. SQL Server host (example: localhost)
        b. Profisee database name (example: Profisee)

Once all parameters are entered, the base_jSync_Govern job and base_pSync_Govern stored procedure will be deleted. Removal of Profisee objects is not handled by this script. Manual intervention is required to remove the Profisee objects.

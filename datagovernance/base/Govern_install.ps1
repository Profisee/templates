#This script will import the Profisee Base Governance model, Staging Tables, Presentation Views, Forms, and FastApp into Profisee which are held in the profisee_objects folder.
#Upon execution, this script will also create the Governance synchronization stored procedure and SQL Agent job. The job is created with default settings of executing once daily at 12:00 a.m.**

[CmdletBinding()]
param(
  [Parameter(Mandatory=$true, HelpMessage="Profisee Server URI (e.g,. http(s)://servername/profisee/api/service.svc)")]
  [String]$profisee_svc_uri,
  [Parameter(Mandatory=$true, HelpMessage="SQL Server Name")]
  [String]$sqlserver_host,
  [Parameter(Mandatory=$true, HelpMessage="Profisee Database Name")]
  [String]$profisee_db,
  [Parameter(Mandatory=$true, HelpMessage="Service Account ClientID")]
  [String]$clientID
)

$profisee_ver='20.2.0'

# Set path for cmd line util
$profisee_cmd_line_utl = $Env:ProgramFiles + '\Profisee\Master Data Maestro Utilities\' + $profisee_ver  + '\Profisee.MasterDataMaestro.Utilities.exe'

# Install model and related objects
& $profisee_cmd_line_utl /URL:$profisee_svc_uri /IMPORT /FILE:$PSScriptRoot\profisee_objects /CLIENTID:$clientID
& $profisee_cmd_line_utl /URL:$profisee_svc_uri /DEPLOYDATA /FILE:$PSScriptRoot\profisee_objects\"Governance Reference Data.archive" /CLIENTID:$clientID

# Install sql server objects
& sqlcmd -S $sqlserver_host -d $profisee_db -i $PSScriptRoot\sql_scripts\base_pSync_Govern.sql
& sqlcmd -S $sqlserver_host -d $profisee_db -i $PSScriptRoot\sql_scripts\base_jSync_Govern.sql


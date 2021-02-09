[CmdletBinding()]
param(
  [Parameter(Mandatory=$true, HelpMessage="SQL Server Name")]
  [String]$sqlserver_host,
  [Parameter(Mandatory=$true, HelpMessage="Profisee Database Name")]
  [String]$profisee_db
)

& sqlcmd -S $sqlserver_host -d $profisee_db -i $PSScriptRoot\sql_scripts\Uninstall.sql
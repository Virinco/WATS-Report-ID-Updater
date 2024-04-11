## WATS Report ID Updater

This application lets you update report IDs of one or more reports in WATS.

### WARNING:
When updating, the affected reports will be inavailable for a short period of time while being reprocessed.
Updating large batches of reports may affect the WATS applications performace while updating.

### Settings:
Supply your WATS service URL, a token and your desired CSV-delimeter in the setting found in the application menu.

### Update from CSV:
When updating from CSV, the application will process the CSV line by line.
Every line must have 7 element, separated by a configurable delipmiter.
Every line has an Action (first column), and a source and destination report ID. (3 + 3 columns)
All reports matching the source ID will be loaded, IDs will be replaced with the destination ID and the report will be resubmitted.

To update from CSV file, make sure the file is of the following format:

#### CSV-Example:
Action;PN;REV;Serial number;PN;REV;SN							<-- Header line is optional (can be skipped by setting)  
Move;OLC-140-C;8;12000087;OLC-140-C;8;12000087_NEW				<-- Report to be updated - Action and source + destination ID  
Move;OLC-140-C;8;12000089;OLC-140-C;8;12000089_NEW				<-- Report to be updated - Action and source + destination ID  

### Columns:
Action:		Can be "Copy" or "Move" - Copy will duplicate the reports to the new ID, Move will change the ID on existing report.  
Source PN	The part number for the unit you want to update. Must have value, no wildcards - should correspond to a existing ID number in WATS.  
Source REV	Source revision - blank is allowed.  
Source SN	The serial number for the unit you want to update. Must have value, no wildcards - should correspond to a existing ID number in WATS.  
Dest PN		The new part number for the unit. Must have value, no wildcards.  
Dest REV	The new revision - blank is allowed.  
Dest SN		The new serial number for the unit. Must have value, no wildcards.  

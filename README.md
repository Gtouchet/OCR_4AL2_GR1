# Clean Code
## Improved OCR

4AL2 - GR1

## Features

- Reads one or multiple files and parse their OCR content as a number
- Verifies if every character is readable in files content  
  Indicates in the result if the OCR is unreadable in the result file(s)
- Applies a checksum on this number  
  Indicates if the checksum is valid or not in the result file(s)
- Writes the result file(s) in solution's 'Output' folder
- A CLI for the user to specify the path and way to create the result file(s) (merged or sorted)

## Usage

The CLI allows the user to specify a file's or a folder's path of the file(s) he wants to process.  
The first given argument is the file/folder path, the second (separated by a comma) is the way the user wants to get the processing's result.  
The program will process all .ocr files and ignore all other files if the first argument is a folder path,  
or the file regardless of its extension if this is a file path.  
The two possible entries for the second argument are : 'merged' or 'sorted', merged by default if unrecognized argument.  
'merged' means that all processed OCR will be merged in a single file, 'sorted' will dispatch them by their status.  

- Status 'authorized' means all characters in this OCR are readable and the checksum is valid.
- Status 'error' means that the checksum is invalid.
- Status 'unreadable' means that one or multiple characters in this OCR are unreadable (replaced by '?').


**Usage examples :**  
```/MyDocuments/MyOcrFilesFolder, sorted```  
-> All .ocr files in MyOcrFilesFolder will be processed and dispatched in separated files depending on their status.  
```/MyDocuments/MyOcrFilesFolder/ThisSpecificFile.ocr, merged```  
-> ThisSpecificFile.ocr will be processed and all OCR contained in this file will be displayed in one result file.  

## Installation

Clone the git repository and execute the program on any Visual Studio IDE.

## Development

IDK but there's a lot to possibly do on this subject :)

## License

This project is not under any software license and is free to reproduce and use.
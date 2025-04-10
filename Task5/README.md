# File I/O and Exception Handling in C#

## What I have done here:
- Created a console application that reads from an input file (`input.txt`).
- Counted the number of **lines** and **words** in the file.
- Wrote the **original content**, **line count**, and **word count** to an output file (`output.txt`).
- Used `StreamWriter` to write data to a file efficiently.
- Implemented **exception handling** to catch and manage:
  - `FileNotFoundException` (if the input file is missing),
  - `IOException` (file access related issues),
  - General exceptions (`Exception`).

## Learned Things:
- **File I/O in C#** using `File.ReadAllLines()`, `File.ReadAllText()`, and `StreamWriter`.
- How to check if a file exists using `File.Exists()`.
- How to **append** or **overwrite** files.
- **Exception Handling** using `try-catch` to catch the exception errors.



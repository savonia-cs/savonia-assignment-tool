# Savonia.Assignment.Tool

This package contains a CLI tool (savoniatool) to help with programming assignments.

The tool can be installed with command:
```dotnetcli
dotnet tool install --global Savonia.Assignment.Tool
```

Contains commands

- `solution pack`: to create a zip package of your solution.
- `submissions unpack`: to unpack (unzip) all answers. Typically each person's answer is in a zip file.
- `submissions list`: to list all answer folders. The list has numbers to the folders and the numbers can be used to select individual or a range of folders to test.
- `submissions test`: to run tests on the submissions.
- `submissions pack`: to pack (zip) all answers. Packs each persons's answer folder individually to zip file.
- `hash create`: to create hash from selected file(s) in answers. Used to find duplicates.
- `hash compare`: to find duplicates among the created hashes.
- `hash open`: to open duplicates in an editor (by default VS Code) for manual checking.
- `csv parse`: to parse a CSV file.

## Usage

When installed the tool can be used as follows

### To pack files

- To pack all \*.cs files in all directories except *obj* and *tests* directories under current working directory to *sourcefiles.zip*

```dotnetcli
savoniatool solution pack --output sourcefiles.zip --verbose --includes "**/*.cs" --excludes "**/obj" "**/tests"
```

`--includes` and `--excludes` options support multiple values without defining the option name multiple times. Use double quotes (") to define arbitrary filters e.g. `"**/*"` for all files in all folders. Leaving the quotes out in MacOS or Linux will result in filter execution before providing the filter value to the option. Check different pattern formats from document [File globbing in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/file-globbing#pattern-formats).

The tool also supports Response files to provide the parameters.

```dotnetcli
savoniatool @respfile.rsp
```

Contents of *respfile.rsp*:
```
solution
pack
--output
sourcefile.zip
--verbose
--includes
"**/*.cs"
--excludes
"**/obj"
"**/tests"
```

### To unpack submissions

- To unpack all submission zip files in a directory

```dotnetcli
savoniatool submissions unpack
```

This will read all .zip files in current directory and unzip them. Each .zip is unzipped in a folder named the same as the .zip file without the .zip extension (e.g. *myanswer.zip* is unpacked to folder *myanswer*).

### To test submissions

- To test all submissions

```dotnetcli
savoniatool submissions test
```

This is used to copy test harness to submission directories, run the tests and report the results.

`submissions test` command has multiple mandatory options, check the tool's help for the options.

Uses `dotnet test` command to run the tests and assumes that there is a solution file (*.sln) in each submissions directory with the test projects included in the solution file.

### To pack submissions

- To pack all submission folders in a directory

```dotnetcli
savoniatool submissions pack
```

This will create a zip file for each subdirectory. The subdirectory itself is not included in the zip file, only files and folders inside the subdirectory. The default values for `--includes` and `--excludes` are good for common usage scenario where all subdirectories in directory defined in option `--path` (default is current directory) are to be packed to individual zip files.

The individual zip files can be packed to a single zip file with command

```dotnetcli
savoniatool submissions pack -o submissions.zip
```

Defining value for option `--output` or `-o` will change the packing behavior to pack resulting files to a single zip file. The default values for `--includes` and `--excludes` are good for common usage scenario where all zip files in directory defined in option `--path` (default is current directory) are to be packed to a single zip file.


### To create hash

- To create hash from selected file(s) in answers

```dotnetcli
savoniatool hash create -o hashes.csv --includes "**/*.cs"
```

This will find all **.cs* files in all directories and creates a hash from the files. Code comments (line and block), white spaces, new lines and carriage returns are removed by default before creating the hash. Hashes are saved in the output file defined with option `-o` (or `--output`).

`--filter-source-code` option uses flags arguments. Define multiple values with comma (,). E.g. `--filter-source-code whitespaces,newlines` to filter out white spaces and new lines. Set option `--filter-source-code none` to create hash from the file as is (without any filtering).

### To check for duplicates

- To check for duplicate hashes

```dotnetcli
savoniatool hash compare --source hashes.csv -o duplicates.csv
```

This will read hashes from source file and write duplicates to output file. By default hash values are read from the last column. Set `--hash-index` option with zero-based index for the hash column if it is not the last column. Define `-v` (or `--verbose`) to see the duplicates in terminal.

### To open duplicates in editor

- To open duplicate source files in editor for manual checking

```dotnetcli
savoniatool hash open --source duplicates.csv
```

This will read hash groups (files that create the same hash value) from source file and open the files with an editor. Uses VS Code as default option to open the files and assumes that the editor is in PATH to allow opening from terminal. Reads filename from the first column and hash value from the last column. Define zero-based index values for options `--file-index` and `--hash-index` if first and last column assumptions are not valid for source file.

> NOTE! This will try to open as many instances of the editor as there are hash groups in the source file. Each instance will open all code files within the hash group. **This may result in excess amounts of editor instances**.

### To parse a CSV file

- To parse required fields from a CSV. The file could be for example downloaded from Moodle LMS's Task activity.

```dotnetcli
savoniatool csv parse --source moodle-csv-file.csv --fields 1 2 3 -o parsed.csv --field-filters 1 \d+
```

This reads fields (or columns) 1, 2 and 3 from source CSV file. Uses regex filter (\d+) to get only numbers from the field 1 and outputs the result to parsed.csv file. The `--field-filters` option is used to define how the selected fields are parsed with regex pattern(s). The regex pattern can be defined in the --field-filters option directly or to a JSON file that is read with option `--regexes`. The JSON file must contain the regexes as a key-value pair (or dictionary with string keys and string values) like:

```json
{
    "num": "\\d+",
    "word": "^([\\w\\-]+)"
}
```

`--field-filters` option references the regex from JSON file with the key value like `--field-filters 3 word` to select the first word from field 3.

The fields in the CSV file can be referenced by number or by name when the CSV file contains a header row. The numbers start from one (1) (i.e. the first field's number is one). Options `--fields` and `--field-filters` both uses the field references.

# Savonia.Assignment.Tool

This package contains a CLI tool (savoniatool) to help with programming assignments.

The tool can be installed with command:
```dotnetcli
dotnet tool install --global Savonia.Assignment.Tool
```

Contains commands

- solution pack: to create a zip package of your solution.
- answers unpack: to unpack (unzip) all answers. Typically each person's answer is in a zip file. 

## Usage

When installed the tool can be used as follows

### To pack files

- To pack all \*.cs files in all directories except *obj* and *tests* directories under current working directory to *sourcefiles.zip*

```dotnetcli
savoniatool solution pack --output sourcefiles.zip --verbose --includes "**/*.cs" --excludes "**/obj" "**/tests"
```

*--includes* and *--excludes* options support multiple parameters without defining the option name multiple times.

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

### To unpack answers

- To unpack all answer zip files in a directory

```dotnetcli
savoniatool answers unpack
```

This will read all .zip files in current directory and unzip them. Each .zip is unzipped in a folder named the same as the .zip file without the .zip extension (e.g. *myanswer.zip* is unpacked to folder *myanswer*).
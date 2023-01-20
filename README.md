# Savonia.Assignment.Tool

This package contains a CLI tool (savoniatool) to help with programming assignments.

The tool can be installed with command:
```dotnetcli
dotnet tool install --global Savonia.Assignment.Tool
```

Contains commands

- solution pack: to create a zip package of your solution.

## Usage

When installed the tool can be used as follows

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

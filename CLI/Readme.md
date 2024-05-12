# Naming Convention Checker

The Naming Convention Checker is a dotnet CLI tool designed to assist developers in enforcing consistent naming conventions in their C# projects. This tool scans C# files and identifies any violations against predefined naming conventions.

## Usage

After installing the package, you can utilize the Naming Convention Checker in various scenarios:

- **Checking Naming Conventions in a Single File:**

  ```bash
  namecheck --file path/to/file
  ```

- **Checking Naming Conventions in All Files within a Directory (Non-Recursively):**

  ```bash
  namecheck --all /path/to/directory
  ```

- **Checking Naming Conventions in All Files within a Directory (Recursively):**
  ```bash
  namecheck --recursive /path/to/directory
  ```

## Configuration

The Naming Convention Checker allows for customization of naming conventions through a template file. You can provide a template file using the `--template` option. Below is an example template file:

**Command**

```bash
namecheck --template /path/to/template/json/file
```

**Template.json**

```json
{
  "RuleName": "Default",
  "NameSpaceRule": {
    "Convention": "PASCALCASE"
  },
  "ClassRule": {
    "PrivateConvention": "PASCALCASE",
    "PublicConvention": "CAMELCASE",
    "InternalConvention": "PASCALCASE   ",
    "ProtectedConvention": "PASCALCASE"
  },
  "InterfaceRule": {
    "PublicConvention": "PASCALCASE",
    "InternalConvention": "PASCALCASE"
  },
  "MethodRule": {
    "PublicConvention": "PASCALCASE",
    "PrivateConvention": "PASCALCASE",
    "InternalConvention": "PASCALCASE",
    "ProtectedConvention": "PASCALCASE"
  },
  "PropertyRule": {
    "PublicConvention": "PASCALCASE",
    "PrivateConvention": "PASCALCASE",
    "InternalConvention": "PASCALCASE",
    "ProtectedConvention": "PASCALCASE"
  },
  "FieldRule": {
    "PublicConvention": "PASCALCASE",
    "PrivateConvention": "PASCALCASE",
    "InternalConvention": "PASCALCASE",
    "ProtectedConvention": "PASCALCASE"
  },
  "StructRule": {
    "PublicConvention": "PASCALCASE",
    "InternalConvention": "PASCALCASE"
  },
  "EnumRule": {
    "Convention": "PASCALCASE"
  },
  "ConstantRule": {
    "Convention": "UPPERCASE"
  },
  "RecordRule": {
    "PublicConvention": "PASCALCASE",
    "InternalConvention": "PASCALCASE"
  },
  "DelegateRule": {
    "PublicConvention": "PASCALCASE",
    "InternalConvention": "PASCALCASE"
  },
  "VariableRule": {
    "Convention": "PASCALCASE"
  }
}
```

_Note : If template is not given in the command. it will take Pascal case for all value as default (convention in the above json)._

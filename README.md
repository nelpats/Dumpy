# Dumpy
### Simple .NET Assembly deobfuscator.

## Supported Mutations
- Abs Mutations
- Length Mutations
- Add Mutations
- Sub Mutations
- Mul Mutations
- Div Mutations
- XOR Mutations
- ToInt32 Mutations
- SizeOf Mutations
- Round Mutations
- EnmptyTypes Mutations
- Double Parser Mutations

## Example
### Before
```
int num = (int)Math.Round(40.0);
int num2 = -8081 + 7242 + (int)double.Parse("871.154178928656") + (sizeof(int) - sizeof(byte)) + Type.EmptyTypes.Length;
Console.WriteLine(num + num2);
Console.Write("Hey !");
Console.ReadLine();
```
### After
```
Console.WriteLine(75);
Console.Write("Hey !");
Console.ReadLine();
```


![Screenshot_4](https://user-images.githubusercontent.com/47573987/101531543-b7b4fe80-3993-11eb-9ce3-e2de1a26000f.png)


## Credits:

Dnlib: 0xd4d/dnlib
Colorful.Console: tomakita/Colorful.Console

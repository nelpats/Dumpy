# Dumpy
### Simple .NET Assembly deobfuscator.

## Features
- Abs Mutations
- Length Mutations
- Add Mutations
- Sub Mutations
- Mul Mutations
- Div Mutations
- XOR Mutations
- ToInt32 Mutations
- SizeOf Mutations

## Example
### Before
```
	int num = Math.Abs((419 + 9) / (3 + 1));
	int num2 = Math.Abs((246 + 4) / 1);
	int value = num + num2;
	Console.WriteLine(value);
```
### After
```
	int num = 428 / 4;
	int num2 = 250;
	int value = num + num2;
	Console.WriteLine(value);
```


![Screenshot_4](https://user-images.githubusercontent.com/47573987/101531543-b7b4fe80-3993-11eb-9ce3-e2de1a26000f.png)


## Credits:

Dnlib: 0xd4d/dnlib
Colorful.Console: tomakita/Colorful.Console

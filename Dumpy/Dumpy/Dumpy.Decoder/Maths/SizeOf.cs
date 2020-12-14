using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
// Credits to RizieBtw for the base of the code

public class SizeOf
    {
        static int count = 0;
        public static void RemoveMutations(ModuleDefMD module)
        {
            foreach (TypeDef typeDef in module.Types)
            {
                foreach (MethodDef method in typeDef.Methods)
                {
                    if (method.HasBody)
                    {
                        if (method.Body.HasInstructions)
                        {

                            IList<Instruction> instr = method.Body.Instructions;
                            for (int i = 0; i < method.Body.Instructions.Count; i++)
                            {
                                if (instr[i].OpCode == OpCodes.Sizeof)
                                {

                                    switch (instr[i].Operand.ToString())
                                    {
                                        case "System.Boolean":
                                            instr[i].OpCode = OpCodes.Ldc_I4_1;
                                            count++;
                                            break;
                                        case "System.Byte":
                                            instr[i].OpCode = OpCodes.Ldc_I4_1;
                                            count++;
                                            break;
                                        case "System.Decimal":
                                            instr[i] = OpCodes.Ldc_I4.ToInstruction(16);
                                            count++;
                                            break;
                                        case "System.Double":
                                        case "System.Int64":
                                        case "System.UInt64":
                                            instr[i].OpCode = OpCodes.Ldc_I4_8;
                                            count++;
                                            break;
                                        case "System.Guid":
                                            instr[i] = OpCodes.Ldc_I4.ToInstruction(16);
                                            count++;
                                            break;
                                        case "System.Int16":
                                        case "System.UInt16":
                                            instr[i].OpCode = OpCodes.Ldc_I4_2;
                                            count++;
                                            break;
                                        case "System.Int32":
                                        case "System.Single":
                                        case "System.UInt32":
                                            instr[i].OpCode = OpCodes.Ldc_I4_4;
                                            count++;
                                            break;
                                        case "System.SByte":
                                            instr[i].OpCode = OpCodes.Ldc_I4_1;
                                            count++;
                                            break;
                                        case "System.Char":
                                            instr[i].OpCode = OpCodes.Ldc_I4_2;
                                            count++;
                                            break;
                                         case "System.UShort":
                                             instr[i].OpCode = OpCodes.Ldc_I4_2;
                                             count++;
                                             break;
                                         case "System.Long":
                                             instr[i].OpCode = OpCodes.Ldc_I4_8;
                                             count++;
                                             break;
                                         case "System.ULong":
                                             instr[i].OpCode = OpCodes.Ldc_I4_8;
                                             count++;
                                             break;
                                }        

                                }
                            }
                        }
                    }
                }
            }
            Logger.Log($"Removed {count} SizeOf mutations");
        }
    }

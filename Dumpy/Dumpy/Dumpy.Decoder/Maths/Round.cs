using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Round
{
    static int count = 0;
    public static void RemoveMutations(ModuleDefMD module)
    {
        // Can create errors 
        foreach (TypeDef types in module.Types)
            foreach (MethodDef method in types.Methods)
            {
                if (method.HasBody)
                    if (method.Body.HasInstructions)
                    {
                        IList<Instruction> instr = method.Body.Instructions;
                        for (int i = 0; i < instr.Count; i++)
                        {
                            if (instr[i].OpCode == OpCodes.Call && instr[i].Operand.ToString().Contains("Round") && instr[i - 1].OpCode == OpCodes.Ldc_R8)
                            {
                                double operand = (double)instr[i - 1].Operand;
                                double convert = Math.Round(operand);
                                instr[i].OpCode = OpCodes.Ldc_R8;
                                instr[i].Operand = convert;
                                instr[i - 1].OpCode = OpCodes.Nop;
                                count++;
                            }
                        }
                    }

            }
        Logger.Log($"Removed {count} Round mutations");


    }
}


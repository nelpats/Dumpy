using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class EmpyTypes
    {
    static int count = 0;
    public static void RemoveMutations(ModuleDefMD module)
    {

        foreach (TypeDef types in module.Types)
            foreach (MethodDef method in types.Methods)
            {
                if (method.HasBody)
                    if (method.Body.HasInstructions)
                    {
                        IList<Instruction> instr = method.Body.Instructions;
                        for (int i = 0; i < instr.Count; i++)
                        {
                            if (instr[i].OpCode == OpCodes.Ldsfld && instr[i].Operand.ToString().Contains("Type::EmptyTypes") && instr[i + 1].OpCode == OpCodes.Ldlen)
                            {
                                instr[i].OpCode = OpCodes.Ldc_I4_0;
                                instr[i + 1].OpCode = OpCodes.Nop;
                                count++;
                            }
                        }
                    }

            }
        Logger.Log($"Removed {count} EmptyTypes mutations");


    }
}


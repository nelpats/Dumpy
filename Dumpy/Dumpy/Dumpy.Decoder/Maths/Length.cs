using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Length
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
                              if (instr[i].OpCode == OpCodes.Call && instr[i].Operand.ToString().Contains("get_Length") && instr[i - 1].OpCode == OpCodes.Ldstr)
                              {
                                  int result = instr[i - 1].Operand.ToString().Length;
                                  instr[i].OpCode = OpCodes.Ldc_I4;
                                  instr[i].Operand = result;
                                  instr[i - 1].OpCode = OpCodes.Nop;
                                  count++;
                              }
                          }
                      }

              }
          Logger.Log($"Removed {count} Length mutations");


      }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Async
{
    public class AsyncMethod
    {
        [NoTrace]
        public AsyncMethod()
        {

        }

        private async Task<int> Double(int p)
        {
            return await Task.Run(() => p * 2);
        }

        public async Task<int> CallMeAsync(int param, string param2, int paraInt)
        {
            var result = await Double(paraInt);
            return result;
        }

        public async Task CallMeReturnNodAsync(string param, string param2, int paraInt)
        {
            var result = await Double(paraInt);
            return;
        }

        private OtherClass _otc = new OtherClass();
        private int _num = 2;

        public async Task<int> CallMeOtherClass(string param, string param2, int paraInt)
        {
            var result = await _otc.Double(paraInt);
            return result * _num;
        }

        public async Task<int> CallMeGeneric<T>(T param, string param2, int paraInt)
        {
            var result = await Double(paraInt);
            return result;
        }

        public async Task<int> Throw(int p)
        {
            return await Task.Run(() => ThrowException());
        }

        private int ThrowException()
        {
            throw new ApplicationException("Err");
            return 1;
        }
    }

    public class OtherClass
    {
        [NoTrace]
        public OtherClass()
        {

        }

        public async Task<int> Double(int p)
        {
            return await DoubleInt(p);
        }

        private async Task<int> DoubleInt(int p)
        {
            return await Task.Run(() => p * 2);
        }
    }
}

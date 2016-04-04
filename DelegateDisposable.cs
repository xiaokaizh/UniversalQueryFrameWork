using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalQueryFrameWork
{

    /********************************************************************************
    ** Author： Xiaokai Zh
    ** Created：2016-03-25
    ** Desc：加入代码创建并使用DelegateDisposable对象
     *       实现IDisposable接口,适当时候调用Diaposable方法
     *       实现对垃圾更加灵活的回收机制
    *********************************************************************************/

    public class DelegateDisposable : IDisposable
    {
        // 指针，指向非托管资源.
        private IntPtr handle;
        //类，托管资源.
        private Component component = new Component();
        // 标志，指示Dispose是否已被调用.
        private bool disposed = false;

        // 构造函数.
        public DelegateDisposable(IntPtr handle)
        {
            this.handle = handle;
        }

        public void Dispose()
        {
            Dispose(true);
            // 调用Dispose需要只是GC不要再调用Finalize（）.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // 检查是否已被调用过.
            if (!this.disposed)
            {
                // 一个标志当在析构函数中，指示为false，别急后续将讲解原因.
                if (disposing)
                {
                    //Dispose托管资源.
                    component.Dispose();
                }

                // 调用Kernel32函数释放非托管资源.
                CloseHandle(handle);
                handle = IntPtr.Zero;

                // 标记已经Dispose了.
                disposed = true;

            }
        }

        // ImportKernel32中的API，关于如何使用Interop我将在后续中讲解.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        //  为了保持代码的可读性性和可维护性,千万不要在这里写释放非托管资源的代码
        // 必须以Dispose(false)方式调用,以false告诉Dispose(bool disposing)函数是从垃圾回
        // 收器在调用Finalize时调用的.
        ~DelegateDisposable()
        {
            Dispose(false);
        }
    }

}

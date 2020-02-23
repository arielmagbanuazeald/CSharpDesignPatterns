using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPatterns.Singleton
{
    /// <summary>
    /// Thread Safety Singleton using Double Check Locking
    /// Reference: https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
    /// </summary>
    public class ThreadSafeDoubleCheckingSingleton
    {
        private static ThreadSafeDoubleCheckingSingleton _instance = null;
        private static readonly object _padlock = new object();

        private ThreadSafeDoubleCheckingSingleton()
        {

        }

        public static ThreadSafeDoubleCheckingSingleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (_padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ThreadSafeDoubleCheckingSingleton();
                        } 
                    }
                }

                return _instance;
            }
        }

        public string Name { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JSONTest
{
    class Program
    {
        static void Main(string[] args)
        {
          
            UserRepository.Create("Andrew", "Galbraith", "hhg4h4-ddd");
            List<User> l = UserRepository.Index();

        }
    }

    
}

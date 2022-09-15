using Microsoft.Extensions.DependencyInjection;
using Nasa.MarsRover.Application.Interfaces;
using Nasa.MarsRover.Application.ViewModels;
using Nasa.MarsRover.Infra.Ioc;
using System;
using System.Collections.Generic;

namespace Nasa.MarsRover.ConsoleApp
{
    /*
     * Criei esse projeto console, para que fosse possivel inserir todas as coodenadas conforme descristo no teste 
     * coodenadas: 5 5 1 2 N LMLMLMLMM 3 3 E MMRMMRMRRM
     * saida: 1 3 N 5 1 E
     */
    class Program
    {
        static void Main(string[] args)
        {
            var services = DependencyInjection.AddResolveDependencies(new ServiceCollection());
            var serviceProvider = services.BuildServiceProvider();
            var _coordinatesAppSevice = serviceProvider.GetService<ICoordinatesAppSevice>();

            Console.Write("Informe as cordenadas : ");
            var coordinates = Console.ReadLine();
            var resultCoordenates = _coordinatesAppSevice.Execute(coordinates);

            List<string> result = resultCoordenates.IsValid
                ? (List<string>)resultCoordenates.Data
                : resultCoordenates.Errors;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}

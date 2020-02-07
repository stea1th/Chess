using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestChess.GameConfiguration;

namespace TestChess.Figures
{
    class FigureRegistry
    {
        public Dictionary<string, Type> FigureTypes { get; set; }

        public Dictionary<int, IFigure> FiguresOnPosition { get; set; }

        public Configuration GameConfiguration { get; }

        public FigureRegistry(Configuration configuration)
        {
            this.GameConfiguration = configuration;
        }


        public void LoadFigureTypes()
        {

            var asm = Assembly.Load("TestChess");
            var types = asm.GetTypes();
            FigureTypes = types.Where(x => x.GetInterface("IFigure") != null && !x.IsAbstract).ToDictionary(x => x.Name.ToLower(), x => x);
        }

        public void SetFiguresOnPosition()
        {
            var configurationFigures = GameConfiguration.Figures.ToList();
            FiguresOnPosition = configurationFigures.Select(x => CreateFigure(x)).ToDictionary(f => f.Position, f => f);
        }

        private IFigure CreateFigure(ConfigurationFigure configurationFigure) 
        {
            FigureTypes.TryGetValue(configurationFigure.type, out Type type);
            return (IFigure)type.GetConstructor(new Type[] { typeof(int), typeof(bool) })
                .Invoke(new object[] { int.Parse(configurationFigure.position), configurationFigure.white });
        }
    }
}

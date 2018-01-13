using System;

namespace CarManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            model.CarRegistry r = new model.CarRegistry();
            view.MasterView v = new view.MasterView();
            controller.Controller c = new controller.Controller();

            v.DisplayMenu();
            while(c.Run(r, v));
        }
    }
}

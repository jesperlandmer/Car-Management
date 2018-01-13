using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarManagement.controller
{
    public class Controller
    {
        public bool Run(model.CarRegistry m_reg, view.MasterView v_view)
        {
            m_reg.LoadDatabase();
            DoGenerateCars(m_reg);
            v_view.DisplayMenu();

            switch (v_view.GetMenuOption())
            {
                case view.MenuOption.AddCar:
                    m_reg.AddCar(v_view.DoCar());
                    return true;
                case view.MenuOption.RemoveCar:
                    m_reg.RemoveCar(v_view.DoRemoveCar());
                    return true;
                case view.MenuOption.Statistics:
                    return DoStatistics(m_reg, v_view);
                    throw new Exception();
                case view.MenuOption.Quit:
                default:
                    return false;
            }
        }

        private void DoGenerateCars(model.CarRegistry m_reg)
        {
            string json = File.ReadAllText("randomCars.json");
            var ja = JArray.Parse(json);

            List<model.Car> Cars = ja.Select(p => new model.Car
            (
                (string)p["plate"],
                new model.Manufacturer(ParseEnum<model.Brand>((string)p["manufacturer"])),
                (string)p["model"],
                new model.Owner((string)p["ssn"], (string)p["name"]),
                (int)p["mileage"],
                (int)p["year"]
            )).ToList();

            foreach (model.Car car in Cars)
            {
                m_reg.AddCar(car);
            }
        }
        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
        }
        private bool DoStatistics(model.CarRegistry m_reg, view.MasterView v_view)
        {
            v_view.DisplayStatsMenu();

            switch (v_view.GetStatsOption())
            {
                case view.StatsOption.OldYoung:
                    v_view.DisplayResult(m_reg.GetOldestAndYoungestOwners());
                    return false;
                case view.StatsOption.PopularBrand:
                    v_view.DisplayResult(m_reg.GetMostPopularBrand());
                    return false;
                case view.StatsOption.AvgDecade:
                    v_view.DisplayResult(m_reg.GetMilesPerDecade());
                    return false;
                case view.StatsOption.AvgBrand:
                    v_view.DisplayResult(m_reg.GetMilesPerBrand());
                    return false;
                case view.StatsOption.AvgMile:
                    v_view.DisplayResult(m_reg.GetMilesPerYear());
                    return false;
                case view.StatsOption.Quit:
                default:
                    return false;
            }
        }
    }
}
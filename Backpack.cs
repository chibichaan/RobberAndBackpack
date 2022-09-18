using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobberAndBackpack
{
    class Backpack
    {                                      //new List<Items>();
        private List<Items> bestItems = null;

        private double maxWeight;

        private double bestPrice;

        /// <summary>
        /// Конструктор. Для создания рюкзака нужно сообщить его макс. грузоподъёмность.
        /// </summary>
        /// <param name="_maxWeight">макс.вес</param>
        public Backpack(double _maxWeight)
        {
            maxWeight = _maxWeight;
        }

        /// <summary>
        /// Метод, который считает весь вес заданного листа
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private double CalculateWeight(List<Items> items)
        {
            double sumWeight = 0;
            foreach (Items i in items)
            {
                sumWeight += i.Weight;
            }

            return sumWeight;
        }
        /// <summary>
        /// Метод, который считает всю цену заданного листа
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private double CalculatePrice(List<Items> items)
        {
            double sumPrice = 0;
            foreach (Items i in items)
            {
                sumPrice += i.Price;
            }

            return sumPrice;
        }

        /// <summary>
        /// Проверка набора на "лучший" из возможных
        /// </summary>
        /// <param name="items">список предметов</param>
        private void CheckSet(List<Items> items)
        {
            if (bestItems == null) //пока не было никакого списка
            {
                if (CalculateWeight(items) <= maxWeight) //проходим ли по весу?
                {
                    bestItems = items;
                    bestPrice = CalculatePrice(items);
                }
            }
            else
            {
                if(CalculateWeight(items) <= maxWeight && CalculatePrice(items) > bestPrice)
                {
                    bestItems = items;
                    bestPrice = CalculatePrice(items);
                }
            }
        }

        /// <summary>
        /// Создание всех перестановок значений.
        /// </summary>
        /// <param name="items">список предметов</param>
        public void MakeAllSets(List<Items> items)
        {
            if (items.Count > 0)
                CheckSet(items);

            for (int i = 0; i < items.Count; i++)
            {
                List<Items> newItems = new List<Items>(items);

                newItems.RemoveAt(i);

                MakeAllSets(newItems);
            }
        } //проверка
        /// <summary>
        /// возвращает решение задачи (набор предметов)
        /// </summary>
        /// <returns></returns>
        public List<Items> GetBestSet()
        {
            return bestItems;
        }

    }
}

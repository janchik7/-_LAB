
namespace IKM1.Models
{
    internal static class DataHND
    {
        //Получение списка недвижимости
        public static List<Property> GetAllProperties()
        {
            using (PostgresContext db = new PostgresContext())
            {
                var result = db.Properties.ToList();
                return result;
            }
        }
        //Получение списка покупателей
        public static List<Buyer> GetAllBuyers()
        {
            using (PostgresContext db = new PostgresContext())
            {
                var result = db.Buyers.ToList();
                return result;
            }
        }
        //Получение списка риелторов
        public static List<Realtor> GetAllRealtors()
        {
            using (PostgresContext db = new PostgresContext())
            {
                var result = db.Realtors.ToList();
                return result;
            }
        }



        //Добавление недвижимости
        public static string AddProperty(string adress, decimal price, string propertytype, int realtorid, int clientid) 
        {
            int id;
            string result = "Уже существует";
            try
            {
                using (PostgresContext db = new PostgresContext())
                {
                    if (db.Properties.Count() != 0)
                    {
                        id = (db.Properties.Max(x => x.PropertyId) + 1);
                    }
                    else
                    {
                        id = 1;
                    }
                    Property newProperty = new Property
                        {
                            PropertyId = id,
                            Address = adress,
                            Price = price,
                            PropertyType = propertytype,
                            RealtorId = realtorid,
                            ClientId = clientid
                        };
                        db.Properties.Add(newProperty);
                        db.SaveChanges();
                        result = "Успешно";
                    
                }
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }

            return result;
        }
        //Добавление покупателя
        public static string AddBuyer( string fullname, string phone, decimal budget)
        {
            string result = "Уже существует";
            try
            {
                int id;
                using (PostgresContext db = new PostgresContext())
                {
                    if (db.Buyers.Count() != 0)
                    {
                        id = (db.Buyers.Max(x => x.BuyerId) + 1);
                    }
                    else
                    {
                        id = 1;
                    }

                    Buyer newBuyer = new Buyer
                        {
                            BuyerId = id,
                            FullName = fullname,
                            Phone = phone,
                            Budget = budget
                        };
                        db.Buyers.Add(newBuyer);
                        db.SaveChanges();
                        result = "Успешно";

                }
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }

            return result;
        }
        //Добавление риелтора
        public static string AddRealtor( string fullname, string phone, decimal comission )
        {
            int id;
            string result = "Уже существует";
            try
            {
                using (PostgresContext db = new PostgresContext())
                {
                    if (db.Realtors.Count() != 0)
                    {
                        id = (db.Realtors.Max(x => x.RealtorId) + 1);
                    }
                    else
                    {
                        id = 1;
                    }
                    Realtor newRealtor = new Realtor
                        {
                            RealtorId = id,
                            FullName = fullname,
                            Phone = phone,
                            CommissionRate = comission
                        };
                        db.Realtors.Add(newRealtor);
                        db.SaveChanges();
                        result = "Успешно";
                    
                }
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }

            return result;
        }
        //Удаление недвижимости
        public static string DelProperty(Property prop)
        {
            string result = "Значение не найдено";
            try
            {
                using (PostgresContext db = new PostgresContext())
                {
                        db.Properties.Remove(prop);
                        db.SaveChanges();
                        result = "Успешно";
                    
                }
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }

            return result;
        }
        //Удаление покупателя
        public static string DelBuyer(Buyer buyer)
        {
            string result = "Значение не найдено";
            try
            {
                using (PostgresContext db = new PostgresContext())
                {

                        db.Buyers.Remove(buyer);
                        db.SaveChanges();
                        result = "Успешно";
                }
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }

            return result;
        }
        //Удаление риелтора
        public static string DelRealtor(Realtor realtor)
        {
            string result = "Знначение не найдено";
            try
            {
                using (PostgresContext db = new PostgresContext())
                {
    
                        db.Realtors.Remove(realtor);
                        db.SaveChanges();
                        result = "Успешно";

                }
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }

            return result;
        }
        //Редактирование недвижимости
        public static string EditProperty(int propertyid, string adress, decimal price, string propertytype, int realtorid, int clientid)
        {
            string result = "Значение не найдено";
            try
            {
                using (PostgresContext db = new PostgresContext())
                {

                        Property newProperty = new Property
                        {
                            PropertyId = propertyid,
                            Address = adress,
                            Price = price,
                            PropertyType = propertytype,
                            RealtorId = realtorid,
                            ClientId = clientid
                        };
                        db.Properties.Update(newProperty);
                        db.SaveChanges();
                        result = "Успешно";

                }
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }

            return result;
        }
        //Редактирование покупателя
        public static string EditBuyer(int buyerid, string fullname, string phone, decimal budget)
        {
            string result = "Значение не найдено";
            try
            {
                using (PostgresContext db = new PostgresContext())
                {
                    if (!(db.Buyers.Any(x => x.FullName == fullname && x.Phone == phone && x.Budget == budget)))
                    {
                        Buyer newBuyer = new Buyer
                        {
                            BuyerId = buyerid,
                            FullName = fullname,
                            Phone = phone,
                            Budget = budget
                        };
                        db.Buyers.Update(newBuyer);
                        db.SaveChanges();
                        result = "Успешно";
                    }
                }
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }

            return result;
        }
        //Редактирование риелтора
        public static string EditRealtor(int realtorid, string fullname, string phone, decimal comission)
        {
            string result = "Знначение не найдено";
            try
            {
                using (PostgresContext db = new PostgresContext())
                {

                        Realtor newRealtor = new Realtor
                        {
                            RealtorId = realtorid,
                            FullName = fullname,
                            Phone = phone,
                            CommissionRate = comission
                        };
                        db.Realtors.Update(newRealtor);
                        db.SaveChanges();
                        result = "Успешно";

                }
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }

            return result;
        }
    }
}

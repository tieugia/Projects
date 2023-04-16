using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MiddleAPI.Services
{
    public class BaseService
    {
        protected readonly IMobileDbContext _jlMobileDbContext;
        public BaseService(IMobileDbContext jlMobileDbContext)
        {
            _jlMobileDbContext = jlMobileDbContext;
        }

        private Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return _jlMobileDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        private Task<T[]> WhereAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return _jlMobileDbContext.Set<T>().AsNoTracking().Where(expression).ToArrayAsync();
        }

        private void Insert<T>(T value) where T : class
        {
            _jlMobileDbContext.Set<T>().Add(value);
        }

        private void InsertList<T>(IEnumerable<T> values) where T : class
        {
            _jlMobileDbContext.Set<T>().AddRange(values);
        }

        private void Update<T>(T currentValue, T newValue) where T : class
        {
            SetValue(currentValue, newValue);
        }

        private void SetValue<T>(T currentValue, T newValue, object id = null) where T : class
        {
            id = id ?? GetValue(currentValue);
            newValue.GetType().GetProperty("Id").SetValue(newValue, id);
            _jlMobileDbContext.Entry(currentValue).State = EntityState.Modified;
            _jlMobileDbContext.Entry(currentValue).CurrentValues.SetValues(newValue);
        }

        private object GetValue<T>(T value, string propName = "Id") where T : class
        {
            return value.GetType().GetProperty(propName).GetValue(value);
        }

        private T FirstByListOfProperties<T>(T oldRecord, IEnumerable<T> newRecords, IEnumerable<string> propertiesOfT) where T : class
        {
            // get the list of property to match
            var properties = propertiesOfT.Select(prop => typeof(T).GetProperty(prop)).ToList();

            // Get one new record where matching one of old records where all the properties equal that old record
            return newRecords.FirstOrDefault(newRecord => properties.All(prop => prop.GetValue(newRecord).Equals(prop.GetValue(oldRecord))));
        }

        private IEnumerable<T> WhereByListOfProperties<T>(IEnumerable<T> oldRecords, IEnumerable<T> newRecords, IEnumerable<string> propertiesOfT) where T : class
        {
            // get the list of property to match
            var properties = propertiesOfT.Select(prop => typeof(T).GetProperty(prop)).ToList();

            // Get all new records where we don't find matching old records where all the properties equal that old record
            return newRecords.Where(newRecord => !oldRecords.Any(oldRecord => properties.All(prop => prop.GetValue(newRecord).Equals(prop.GetValue(oldRecord))))).ToArray();
        }

        private object[] UpdateList<T>(IEnumerable<T> currentValues, IEnumerable<T> newValues, string[] propNames) where T : class
        {
            var ids = new List<object>();
            foreach (var currentValue in currentValues)
            {
                T newValue = null;
                if (propNames == null)
                {
                    var currentValueId = GetValue(currentValue);
                    newValue = newValues.FirstOrDefault(value => GetValue(value).Equals(currentValueId));
                }
                else
                {
                    newValue = FirstByListOfProperties(currentValue, newValues, propNames);
                }

                if (newValue != null)
                {
                    SetValue(currentValue, newValue);
                    ids.Add(GetValue(newValue));
                }
            }

            return ids.ToArray();
        }

        protected async Task InsertOrUpdateAsync<T>(Expression<Func<T, bool>> expression, T newRecord) where T : class
        {
            var existingRecord = await FirstOrDefaultAsync(expression);

            if (existingRecord != null)
            {
                Update(existingRecord, newRecord);
                return;
            }

            Insert(newRecord);
            return;
        }

        protected async Task InsertOrUpdateListAsync<T>(Expression<Func<T, bool>> expressionForExistingRecords, IEnumerable<T> newRecords, string[] propNames = null) where T : class
        {
            var existingRecords = await WhereAsync(expressionForExistingRecords);

            var ids = new List<object>();

            if (existingRecords != null && existingRecords.Any())
            {
                ids.AddRange(UpdateList(existingRecords, newRecords, propNames));
                newRecords = propNames == null && ids.Any() ? newRecords.Where(newRecord => !ids.Contains(GetValue(newRecord))).ToArray() : WhereByListOfProperties(existingRecords, newRecords, propNames);
            }

            if (newRecords.Any())
            {
                InsertList(newRecords);
            }
        }
    }
}

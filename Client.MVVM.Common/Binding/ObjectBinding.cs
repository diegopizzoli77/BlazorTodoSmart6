using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client.MVVM.Common.Binding
{
    /// <summary>
    /// Copia i valori con corrispondente proprietà e tipo tra un oggetto di tipo TSource a un oggetto destinataio TTarget
    /// </summary>
    /// <typeparam name="TSource">Tipo di oggetto sorgente</typeparam>
    /// <typeparam name="TTarget">Tipo di oggetto destinatario</typeparam>
    public class ObjectBinding<TSource, TTarget> where TSource : class where TTarget : class
    {

        #region Public Methods
        /// <summary>
        /// Copia le proprietà da un oggetto sorgente a un oggetto destinatario
        /// </summary>
        /// <param name="source">Oggetto Sorgente</param>
        /// <param name="target">Oggetto Destinatario</param>
        public static async Task Copy(TSource source, TTarget target)
        {
            await Task.Run(() => copyObj(source, target));
        }

        /// <summary>
        /// Copia le proprietà da un oggetto sorgente a un oggetto destinatario usando il parallelismo
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static async Task ParallelCopy(TSource source, TTarget target)
        {
            await Task.Run(() => parallelCopyObj(source, target));
        }
        #endregion

        #region Private Methods

        private static void copyObj(TSource source, TTarget target)
        {
            var parentProperties = source.GetType().GetProperties();
            var childProperties = target.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(target, parentProperty.GetValue(source));
                        break;
                    }
                }
            }
        }

        private static void parallelCopyObj(TSource source, TTarget target)
        {
            var parentProperties = source.GetType().GetProperties();
            var childProperties = target.GetType().GetProperties();

            Parallel.ForEach(parentProperties, parentProperty =>
            {
                CopyProperty(source, target, parentProperty, childProperties);
            });
        }

        private static void CopyProperty(TSource source, TTarget target, PropertyInfo parentProperty, PropertyInfo[] childProperties)
        {
            Parallel.ForEach(childProperties, (childProperty, state) =>
            {
                if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                {
                    childProperty.SetValue(target, parentProperty.GetValue(source));
                    state.Break();
                }
            });
        }

        #endregion


    }
}

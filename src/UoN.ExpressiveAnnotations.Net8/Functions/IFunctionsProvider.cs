/* https://github.com/MrDoe/UoN.ExpressiveAnnotations.Net8
 * Original work Copyright (c) 2014 Jarosław Waliszko
 * Modified work Copyright (c) 2018 The University of Nottingham
 * Modified work Copyright (c) 2023 Christoph Döllinger
 * Licensed MIT: http://opensource.org/licenses/MIT */

using System.Collections.Generic;
using System.Linq.Expressions;
using UoN.ExpressiveAnnotations.Net8.Analysis;

namespace UoN.ExpressiveAnnotations.Net8.Functions
{
    /// <summary>
    ///     Functions source.
    /// </summary>
    public interface IFunctionsProvider
    {
        /// <summary>
        ///     Gets functions for the <see cref="Parser" />.
        /// </summary>
        /// <returns>
        ///     Registered functions.
        /// </returns>
        IDictionary<string, IList<LambdaExpression>> GetFunctions();
    }
}

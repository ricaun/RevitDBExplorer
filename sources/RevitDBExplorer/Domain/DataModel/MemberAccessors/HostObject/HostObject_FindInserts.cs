﻿using System.Collections.Generic;
using System.Linq.Expressions;
using Autodesk.Revit.DB;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.DataModel.MemberAccessors
{
    internal class HostObject_FindInserts : MemberAccessorByFunc<HostObject, IList<ElementId>>, ICanCreateMemberAccessor
    {
        IEnumerable<LambdaExpression> ICanCreateMemberAccessor.GetHandledMembers() { yield return (HostObject x) => x.FindInserts(true, true, true, true); }


        public HostObject_FindInserts() : base((document, hostObject) => hostObject.FindInserts(true, true, true, true))
        {

        }
    }
}
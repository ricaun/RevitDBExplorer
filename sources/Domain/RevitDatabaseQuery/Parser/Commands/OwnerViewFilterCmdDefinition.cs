﻿using System.Collections.Generic;
using RevitDBExplorer.WPF.Controls;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.RevitDatabaseQuery.Parser.Commands
{
    internal class OwnerViewFilterCmdDefinition : ICommandDefinition
    {
        private static readonly AutocompleteItem AutocompleteItem = new AutocompleteItem("owned", "owned", "select elements which are owned by a active view", AutocompleteItemGroups.Commands);


        public IAutocompleteItem GetCommandAutocompleteItem() => AutocompleteItem;


        public IEnumerable<string> GetClassifiers()
        {
            yield break;
        }
        public IEnumerable<string> GetKeywords()
        {
            yield return "owned";            
        }
        public bool CanRecognizeArgument(string argument) => false;
        public bool CanParticipateInGenericSearch() => false;


        public ICommand Create(string cmdText, string argument)
        {
            return new OwnerViewFilterCmd(cmdText);
        }
    }


    internal class OwnerViewFilterCmd : Command
    {
        public OwnerViewFilterCmd(string text) : base(CmdType.Owned, text, null, null)
        {
            IsBasedOnQuickFilter = true;
        }
    }
}
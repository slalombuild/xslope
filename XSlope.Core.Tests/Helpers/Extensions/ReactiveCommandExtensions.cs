using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ReactiveUI;

namespace XSlope.Core.Tests.Helpers.Extensions
{
    public static class ReactiveCommandExtensions
    {
        public static void TriggerExecution(this ReactiveCommand command)
        {
            var source = new Subject<Unit>();
            source.InvokeCommand(command);
            source.OnNext(Unit.Default);
        }
    }
}

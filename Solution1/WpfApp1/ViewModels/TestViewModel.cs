using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class TestViewModel : BindableBase
    {
        private TestModel model;

        public ReactiveProperty<string> Text { get; set; }
        public ReactiveCommand TestCommand { get; } = new ReactiveCommand();
        public TestViewModel()
        {
            model = new TestModel();
            Text = model
                .ToReactivePropertyAsSynchronized(
                    x => x.Test,
                    //convert: x => x,
                    //convertBack: x => x);
                    convert: x => x?.ToString(),
                    convertBack: x => decimal.Parse(x),
                    ignoreValidationErrorValue: true)
                .SetValidateNotifyError(x =>
                {
                    return decimal.TryParse(x, out decimal result) ? null : "error";
                });

                //convertBack: x =>
                //{
                //    Console.WriteLine("zzzzz " + x);
                //    if (string.IsNullOrEmpty(x))
                //    {
                //        return null;
                //    }
                //    decimal ret;
                //    if (decimal.TryParse(x, out ret))
                //    {
                //        return ret;
                //    }
                //    return null;
                //});

            TestCommand.Subscribe(_ => ExecuteTest());
        }

        private void ExecuteTest()
        {
            Console.WriteLine("VM : " + Text.Value);
            model.ExecuteTest();
        }
    }
}

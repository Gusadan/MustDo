using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MustDo
{
    [Activity(Label = "AddItemActivity")]
    public class AddItemActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_add_item);

            var buttonAdd = FindViewById<Button>(Resource.Id.buttonAddTask);
            var editTextTaskName = FindViewById<EditText>(Resource.Id.editTextTaskName);

            buttonAdd.Click += delegate {
                Log.Debug("***** DEBUG *****", "Textfield contains " + editTextTaskName.Text);
            };
        }
    }
}
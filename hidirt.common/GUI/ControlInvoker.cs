
///<summary>
///
/// Class:
/// ControlInvoker
///
/// Purpose:
/// Offers functions for threadsafe access to objects of Windows Forms controls.
///
/// Originally written by:
/// Rainer Hilmer & Marcel Spies
/// http://dotnet-snippets.de/snippet/threadsichere-und-generische-kommunikation-windows-forms/1072
///
/// Extended by:
/// Michael Kipp
///
///</summary>

using System;
using System.Reflection;
using System.Windows.Forms;

public class ControlInvoker
{
   #region Delegates

   private delegate void MethodCaller<ControlType>(
      ControlType control, string methodName, params object[] parameters)
      where ControlType : Control;

   private delegate object PropertyValueReaderCallback<ControlType>(
      ControlType control, string propertyName)
      where ControlType : Control;

   private delegate object PropertyValueReaderCallback(
      Control control, string propertyName);

   private delegate void PropertyValueWriterCallback<ControlType, PropertyType>(
      ControlType control, string propertyName, PropertyType value)
      where ControlType : Control;

   private delegate void PropertyValueWriterCallback<PropertyType>(
      Control control, string propertyName, PropertyType value);

   #endregion Delegates
   
   #region Methods
   
   Control _form = null;
   
   public ControlInvoker()
   {
   }

   public ControlInvoker(Control form)
   {
      _form = form;
   }

   /// <summary>
   /// Invokes a control method call.
   /// </summary>
   /// <typeparam name="ControlType">The type of the control.</typeparam>
   /// <param name="control">The control.</param>
   /// <param name="methodName">Name of the method.</param>
   /// <param name="parameters">Parameters array for the method to be called.</param>
   public void InvokeControlMethodCall<ControlType>(
      ControlType control,
      string methodName,
      params object[] parameters)
      where ControlType : Control
   {
      if(control.InvokeRequired)
      {
         MethodCaller<ControlType> callerDelegate = InvokeControlMethodCall;
         control.Invoke(callerDelegate, new object[] { control, methodName, parameters });
      }
      else
      {
         MethodInfo method = control.GetType().GetMethod(methodName);
         method.Invoke(control, parameters);
      }
   }

   /// <summary>
   /// Invokes reading of a control property.
   /// </summary>
   /// <typeparam name="ControlType">The type of the control.</typeparam>
   /// <param name="control">The control.</param>
   /// <param name="propertyName">Name of the property.</param>
   /// <returns>The value.</returns>
   public object InvokeControlPropertyReader<ControlType>(
      ControlType control,
      string propertyName)
      where ControlType : Control
   {
      if(control.InvokeRequired)
      {
         PropertyValueReaderCallback<ControlType> cb = InvokeControlPropertyReader;
         return control.Invoke(cb, new object[] { control, propertyName });
      }
      PropertyInfo property = control.GetType().GetProperty(propertyName);
      return property.GetValue(control, null);
   }

   /// <summary>
   /// Invokes reading of a control property.
   /// </summary>
   /// <param name="controlName">Name of the control.</param>
   /// <param name="propertyName">Name of the property.</param>
   /// <returns>The value.</returns>
   public object InvokeControlPropertyReader(
      string controlName,
      string propertyName)
   {
      if(_form != null)
      {
         Control control = null;
         Control[] controls = _form.Controls.Find(controlName, true);
         if(controls.Length > 0)
         {
            control = controls[0];
   
            if(control.InvokeRequired)
            {
               PropertyValueReaderCallback cb = InvokeControlPropertyReader;
               return control.Invoke(cb, new object[] { control, propertyName });
            }
            PropertyInfo property = control.GetType().GetProperty(propertyName);
            return property.GetValue(control, null);
         }
      }
      return null;
   }

   /// <summary>
   /// Invokes writing to a control property.
   /// </summary>
   /// <typeparam name="ControlType">The type of the control.</typeparam>
   /// <typeparam name="PropertyType">The type of the property.</typeparam>
   /// <param name="control">The control.</param>
   /// <param name="propertyName">Name of the property.</param>
   /// <param name="value">The value.</param>
   public void InvokeControlPropertyWriter<ControlType, PropertyType>(
      ControlType control,
      string propertyName,
      PropertyType value)
      where ControlType : Control
   {
      if(control.InvokeRequired)
      {
         PropertyValueWriterCallback<ControlType, PropertyType> cb = InvokeControlPropertyWriter;
         control.Invoke(cb, new object[] { control, propertyName, value });
      }
      else
      {
         PropertyInfo property = control.GetType().GetProperty(propertyName);
         property.SetValue(control, value, null);
      }
   }

   /// <summary>
   /// Invokes writing to a control property.
   /// </summary>
   /// <typeparam name="PropertyType">The type of the property.</typeparam>
   /// <param name="controlName">Name of the control.</param>
   /// <param name="propertyName">Name of the property.</param>
   /// <param name="value">The value.</param>
   public void InvokeControlPropertyWriter<PropertyType>(
      string controlName,
      string propertyName,
      PropertyType value)
   {
      if(_form != null)
      {
         Control control = null;
         Control[] controls = _form.Controls.Find(controlName, true);
         if(controls.Length > 0)
         {
            control = controls[0];
   
            if(control.InvokeRequired)
            {
               PropertyValueWriterCallback<PropertyType> cb = InvokeControlPropertyWriter;
               control.Invoke(cb, new object[] { control, propertyName, value });
            }
            else
            {
               PropertyInfo property = control.GetType().GetProperty(propertyName);
               property.SetValue(control, value, null);
            }
         }
      }
   }

   #endregion Methods
}
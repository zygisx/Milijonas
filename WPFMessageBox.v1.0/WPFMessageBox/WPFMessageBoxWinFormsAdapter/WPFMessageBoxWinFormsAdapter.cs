using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;

namespace MessageBoxUtils
{
    public static class WPFMessageBoxWinFormsAdapter
    {
        //
        // Summary:
        //     Displays a message box in front of the specified object and with the specified
        //     text.
        //
        // Parameters:
        //   owner:
        //     An implementation of System.Windows.Forms.IWin32Window that will own the
        //     modal dialog box.
        //
        //   text:
        //     The text to display in the message box.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        public static System.Windows.Forms.DialogResult Show(System.Windows.Forms.IWin32Window owner, string text)
        {
            return Translate(ShowCore(owner, text));
        }

        //
        // Summary:
        //     Displays a message box in front of the specified object and with the specified
        //     text and caption.
        //
        // Parameters:
        //   owner:
        //     An implementation of System.Windows.Forms.IWin32Window that will own the
        //     modal dialog box.
        //
        //   text:
        //     The text to display in the message box.
        //
        //   caption:
        //     The text to display in the title bar of the message box.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        public static System.Windows.Forms.DialogResult Show(System.Windows.Forms.IWin32Window owner, string text, string caption)
        {
            return Translate(ShowCore(owner, text, caption));
        }

        //
        // Summary:
        //     Displays a message box with specified text, caption, and buttons.
        //
        // Parameters:
        //   text:
        //     The text to display in the message box.
        //
        //   caption:
        //     The text to display in the title bar of the message box.
        //
        //   buttons:
        //     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
        //     buttons to display in the message box.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     The buttons parameter specified is not a member of System.Windows.Forms.MessageBoxButtons.
        //
        //   System.InvalidOperationException:
        //     An attempt was made to display the System.Windows.Forms.MessageBox in a process
        //     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
        //     property.
        public static System.Windows.Forms.DialogResult Show(string text, string caption, System.Windows.Forms.MessageBoxButtons buttons)
        {
            return Translate(ShowCore(null, text, caption, Translate(buttons)));
        }

        //
        // Summary:
        //     Displays a message box in front of the specified object and with the specified
        //     text, caption, and buttons.
        //
        // Parameters:
        //   owner:
        //     An implementation of System.Windows.Forms.IWin32Window that will own the
        //     modal dialog box.
        //
        //   text:
        //     The text to display in the message box.
        //
        //   caption:
        //     The text to display in the title bar of the message box.
        //
        //   buttons:
        //     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
        //     buttons to display in the message box.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     buttons is not a member of System.Windows.Forms.MessageBoxButtons.
        //
        //   System.InvalidOperationException:
        //     An attempt was made to display the System.Windows.Forms.MessageBox in a process
        //     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
        //     property.
        public static System.Windows.Forms.DialogResult Show(System.Windows.Forms.IWin32Window owner, string text, string caption, System.Windows.Forms.MessageBoxButtons buttons)
        {
            return Translate(ShowCore(owner, text, caption, Translate(buttons)));
        }

        //
        // Summary:
        //     Displays a message box with specified text, caption, buttons, and icon.
        //
        // Parameters:
        //   text:
        //     The text to display in the message box.
        //
        //   caption:
        //     The text to display in the title bar of the message box.
        //
        //   buttons:
        //     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
        //     buttons to display in the message box.
        //
        //   icon:
        //     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
        //     icon to display in the message box.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     The buttons parameter specified is not a member of System.Windows.Forms.MessageBoxButtons.-or-
        //     The icon parameter specified is not a member of System.Windows.Forms.MessageBoxIcon.
        //
        //   System.InvalidOperationException:
        //     An attempt was made to display the System.Windows.Forms.MessageBox in a process
        //     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
        //     property.
        public static System.Windows.Forms.DialogResult Show(string text, string caption, System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon)
        {
            return Translate(ShowCore(null, text, caption, Translate(buttons), Translate(icon)));
        }

        //
        // Summary:
        //     Displays a message box in front of the specified object and with the specified
        //     text, caption, buttons, and icon.
        //
        // Parameters:
        //   owner:
        //     An implementation of System.Windows.Forms.IWin32Window that will own the
        //     modal dialog box.
        //
        //   text:
        //     The text to display in the message box.
        //
        //   caption:
        //     The text to display in the title bar of the message box.
        //
        //   buttons:
        //     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
        //     buttons to display in the message box.
        //
        //   icon:
        //     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
        //     icon to display in the message box.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
        //     is not a member of System.Windows.Forms.MessageBoxIcon.
        //
        //   System.InvalidOperationException:
        //     An attempt was made to display the System.Windows.Forms.MessageBox in a process
        //     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
        //     property.
        public static System.Windows.Forms.DialogResult Show(System.Windows.Forms.IWin32Window owner, string text, string caption, System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon)
        {
            return Translate(ShowCore(owner, text, caption, Translate(buttons), Translate(icon)));
        }

        //
        // Summary:
        //     Displays a message box with the specified text, caption, buttons, icon, and
        //     default button.
        //
        // Parameters:
        //   text:
        //     The text to display in the message box.
        //
        //   caption:
        //     The text to display in the title bar of the message box.
        //
        //   buttons:
        //     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
        //     buttons to display in the message box.
        //
        //   icon:
        //     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
        //     icon to display in the message box.
        //
        //   defaultButton:
        //     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
        //     the default button for the message box.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
        //     is not a member of System.Windows.Forms.MessageBoxIcon.-or- defaultButton
        //     is not a member of System.Windows.Forms.MessageBoxDefaultButton.
        //
        //   System.InvalidOperationException:
        //     An attempt was made to display the System.Windows.Forms.MessageBox in a process
        //     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
        //     property.
        public static System.Windows.Forms.DialogResult Show(string text, string caption, System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon, System.Windows.Forms.MessageBoxDefaultButton defaultButton)
        {
            return Translate(ShowCore(null, text, caption, Translate(buttons), Translate(icon), Translate(defaultButton, buttons)));
        }

        //
        // Summary:
        //     Displays a message box in front of the specified object and with the specified
        //     text, caption, buttons, icon, and default button.
        //
        // Parameters:
        //   owner:
        //     An implementation of System.Windows.Forms.IWin32Window that will own the
        //     modal dialog box.
        //
        //   text:
        //     The text to display in the message box.
        //
        //   caption:
        //     The text to display in the title bar of the message box.
        //
        //   buttons:
        //     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
        //     buttons to display in the message box.
        //
        //   icon:
        //     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
        //     icon to display in the message box.
        //
        //   defaultButton:
        //     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
        //     the default button for the message box.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
        //     is not a member of System.Windows.Forms.MessageBoxIcon.-or- defaultButton
        //     is not a member of System.Windows.Forms.MessageBoxDefaultButton.
        //
        //   System.InvalidOperationException:
        //     An attempt was made to display the System.Windows.Forms.MessageBox in a process
        //     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
        //     property.
        public static System.Windows.Forms.DialogResult Show(System.Windows.Forms.IWin32Window owner, string text, string caption, System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon, System.Windows.Forms.MessageBoxDefaultButton defaultButton)
        {
            return Translate(ShowCore(owner, text, caption, Translate(buttons), Translate(icon), Translate(defaultButton, buttons)));
        }

        //
        // Summary:
        //     Displays a message box with the specified text, caption, buttons, icon, default
        //     button, and options.
        //
        // Parameters:
        //   text:
        //     The text to display in the message box.
        //
        //   caption:
        //     The text to display in the title bar of the message box.
        //
        //   buttons:
        //     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
        //     buttons to display in the message box.
        //
        //   icon:
        //     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
        //     icon to display in the message box.
        //
        //   defaultButton:
        //     One of the System.Windows.Forms.MessageBoxDefaultButton values that specifies
        //     the default button for the message box.
        //
        //   options:
        //     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
        //     display and association options will be used for the message box. You may
        //     pass in 0 if you wish to use the defaults.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
        //     is not a member of System.Windows.Forms.MessageBoxIcon.-or- The defaultButton
        //     specified is not a member of System.Windows.Forms.MessageBoxDefaultButton.
        //
        //   System.InvalidOperationException:
        //     An attempt was made to display the System.Windows.Forms.MessageBox in a process
        //     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
        //     property.
        //
        //   System.ArgumentException:
        //     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
        //     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- buttons
        //     specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
        public static System.Windows.Forms.DialogResult Show(string text, string caption, System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon, System.Windows.Forms.MessageBoxDefaultButton defaultButton, System.Windows.Forms.MessageBoxOptions options)
        {
            return Translate(ShowCore(null, text, caption, Translate(buttons), Translate(icon), Translate(defaultButton, buttons), Translate(options)));
        }

        //
        // Summary:
        //     Displays a message box in front of the specified object and with the specified
        //     text, caption, buttons, icon, default button, and options.
        //
        // Parameters:
        //   owner:
        //     An implementation of System.Windows.Forms.IWin32Window that will own the
        //     modal dialog box.
        //
        //   text:
        //     The text to display in the message box.
        //
        //   caption:
        //     The text to display in the title bar of the message box.
        //
        //   buttons:
        //     One of the System.Windows.Forms.MessageBoxButtons values that specifies which
        //     buttons to display in the message box.
        //
        //   icon:
        //     One of the System.Windows.Forms.MessageBoxIcon values that specifies which
        //     icon to display in the message box.
        //
        //   defaultButton:
        //     One of the System.Windows.Forms.MessageBoxDefaultButton values the specifies
        //     the default button for the message box.
        //
        //   options:
        //     One of the System.Windows.Forms.MessageBoxOptions values that specifies which
        //     display and association options will be used for the message box. You may
        //     pass in 0 if you wish to use the defaults.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        //
        // Exceptions:
        //   System.ComponentModel.InvalidEnumArgumentException:
        //     buttons is not a member of System.Windows.Forms.MessageBoxButtons.-or- icon
        //     is not a member of System.Windows.Forms.MessageBoxIcon.-or- defaultButton
        //     is not a member of System.Windows.Forms.MessageBoxDefaultButton.
        //
        //   System.InvalidOperationException:
        //     An attempt was made to display the System.Windows.Forms.MessageBox in a process
        //     that is not running in User Interactive mode. This is specified by the System.Windows.Forms.SystemInformation.UserInteractive
        //     property.
        //
        //   System.ArgumentException:
        //     options specified both System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly
        //     and System.Windows.Forms.MessageBoxOptions.ServiceNotification.-or- options
        //     specified System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly or System.Windows.Forms.MessageBoxOptions.ServiceNotification
        //     and specified a value in the owner parameter. These two options should be
        //     used only if you invoke the version of this method that does not take an
        //     owner parameter.-or- buttons specified an invalid combination of System.Windows.Forms.MessageBoxButtons.
        public static System.Windows.Forms.DialogResult Show(System.Windows.Forms.IWin32Window owner, string text, string caption, System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon, System.Windows.Forms.MessageBoxDefaultButton defaultButton, System.Windows.Forms.MessageBoxOptions options)
        {
            return Translate(ShowCore(owner, text, caption, Translate(buttons), Translate(icon), Translate(defaultButton, buttons), Translate(options)));
        }

        private static System.Windows.Forms.DialogResult Translate(System.Windows.MessageBoxResult result)
        {
            switch (result)
            {
                case System.Windows.MessageBoxResult.None:
                    return System.Windows.Forms.DialogResult.None;

                case System.Windows.MessageBoxResult.OK:
                    return System.Windows.Forms.DialogResult.OK;

                case System.Windows.MessageBoxResult.Cancel:
                    return System.Windows.Forms.DialogResult.Cancel;

                case System.Windows.MessageBoxResult.Yes:
                    return System.Windows.Forms.DialogResult.Yes;

                case System.Windows.MessageBoxResult.No:
                    return System.Windows.Forms.DialogResult.No;

                default:
                    throw new NotSupportedException();
            }
        }

        private static System.Windows.MessageBoxButton Translate(System.Windows.Forms.MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case System.Windows.Forms.MessageBoxButtons.OK:
                    return System.Windows.MessageBoxButton.OK;

                case System.Windows.Forms.MessageBoxButtons.OKCancel:
                    return System.Windows.MessageBoxButton.OKCancel;

                case System.Windows.Forms.MessageBoxButtons.YesNo:
                    return System.Windows.MessageBoxButton.YesNo;

                case System.Windows.Forms.MessageBoxButtons.YesNoCancel:
                    return System.Windows.MessageBoxButton.YesNoCancel;

                default:
                    throw new NotSupportedException();
            }
        }

        private static System.Windows.MessageBoxImage Translate(System.Windows.Forms.MessageBoxIcon icon)
        {
            switch (icon)
            {
                case System.Windows.Forms.MessageBoxIcon.None:
                    return System.Windows.MessageBoxImage.None;

                //case System.Windows.Forms.MessageBoxIcon.Hand:
                //case System.Windows.Forms.MessageBoxIcon.Stop:
                case System.Windows.Forms.MessageBoxIcon.Error:
                    return System.Windows.MessageBoxImage.Error;

                case System.Windows.Forms.MessageBoxIcon.Question:
                    return System.Windows.MessageBoxImage.Question;

                //case System.Windows.Forms.MessageBoxIcon.Exclamation:
                case System.Windows.Forms.MessageBoxIcon.Warning:
                    return System.Windows.MessageBoxImage.Warning;

                //case System.Windows.Forms.MessageBoxIcon.Asterisk:
                case System.Windows.Forms.MessageBoxIcon.Information:
                    return System.Windows.MessageBoxImage.Information;

                default:
                    throw new NotSupportedException();
            }
        }

        private static System.Windows.MessageBoxResult Translate(System.Windows.Forms.MessageBoxDefaultButton defaultButton, System.Windows.Forms.MessageBoxButtons buttons)
        {
            switch (defaultButton)
            {
                case System.Windows.Forms.MessageBoxDefaultButton.Button1:
                    switch (buttons)
                    {
                        case System.Windows.Forms.MessageBoxButtons.OK:
                            return System.Windows.MessageBoxResult.OK;

                        case System.Windows.Forms.MessageBoxButtons.OKCancel:
                            return System.Windows.MessageBoxResult.OK;

                        case System.Windows.Forms.MessageBoxButtons.YesNo:
                            return System.Windows.MessageBoxResult.Yes;

                        case System.Windows.Forms.MessageBoxButtons.YesNoCancel:
                            return System.Windows.MessageBoxResult.Yes;

                        default:
                            throw new NotSupportedException();
                    }

                case System.Windows.Forms.MessageBoxDefaultButton.Button2:
                    switch (buttons)
                    {
                        case System.Windows.Forms.MessageBoxButtons.OKCancel:
                            return System.Windows.MessageBoxResult.Cancel;

                        case System.Windows.Forms.MessageBoxButtons.YesNo:
                            return System.Windows.MessageBoxResult.No;

                        case System.Windows.Forms.MessageBoxButtons.YesNoCancel:
                            return System.Windows.MessageBoxResult.No;

                        default:
                            throw new NotSupportedException();
                    }

                case System.Windows.Forms.MessageBoxDefaultButton.Button3:
                    switch (buttons)
                    {
                        case System.Windows.Forms.MessageBoxButtons.YesNoCancel:
                            return System.Windows.MessageBoxResult.Cancel;

                        default:
                            throw new NotSupportedException();
                    }
            }

            throw new NotSupportedException();
        }

        private static System.Windows.MessageBoxOptions Translate(System.Windows.Forms.MessageBoxOptions options)
        {
            switch (options)
            {
                case 0:
                    return MessageBoxOptions.None;

                case System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly:
                    return System.Windows.MessageBoxOptions.DefaultDesktopOnly;

                case System.Windows.Forms.MessageBoxOptions.ServiceNotification:
                    return System.Windows.MessageBoxOptions.ServiceNotification;

                case System.Windows.Forms.MessageBoxOptions.RightAlign:
                    return System.Windows.MessageBoxOptions.RightAlign;

                case System.Windows.Forms.MessageBoxOptions.RtlReading:
                    return System.Windows.MessageBoxOptions.RtlReading;
            }

            throw new NotSupportedException();
        }

        private static MessageBoxResult ShowCore(
            System.Windows.Forms.IWin32Window owner,
            string messageBoxText,
            string caption = "",
            MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage icon = MessageBoxImage.None,
            MessageBoxResult defaultResult = MessageBoxResult.None,
            MessageBoxOptions options = MessageBoxOptions.None)
        {
            return WPFMessageBoxWindow.Show(
                delegate(Window messageBoxWindow)
                {
                    if (owner != null)
                    {
                        WindowInteropHelper helper = new WindowInteropHelper(messageBoxWindow);
                        helper.Owner = owner.Handle;
                    }
                },
                messageBoxText, caption, button, icon, defaultResult, options);
        }
    }
}

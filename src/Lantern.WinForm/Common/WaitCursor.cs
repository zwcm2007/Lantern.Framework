using System;
using System.Windows;
using System.Windows.Input;

namespace HouHeng.WinForm.Common
{
    public sealed class WaitCursor : IDisposable
    {
        private Cursor _cursor;
        private Window _owner;

        public WaitCursor()
        {
        }

        public WaitCursor(Window owner)
        {
            _owner = owner;
            _cursor = _owner.Cursor;
            _owner.Cursor = Cursors.Wait;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~WaitCursor()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_owner != null)
                {
                    if (_cursor != null)
                        _owner.Cursor = _cursor;
                    else
                        _owner.Cursor = null;
                }

                _cursor = null;
                _owner = null;
            }
        }
    }
}
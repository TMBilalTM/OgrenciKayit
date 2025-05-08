using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OgrenciKayit
{
    // ...existing code...
    public static class FormUtils
    {
        // Helper to apply rounded corners to controls
        public static void ApplyRoundedCorners(Control control, int radius = 8)
        {
            control.Region = System.Drawing.Region.FromHrgn(
                NativeMethods.CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius));
        }

        // Call this in the form's constructor or Load event for modern look
        public static void ApplyModernStyle(Form form)
        {
            form.BackColor = ThemeColors.Background;
            form.Font = new Font("Segoe UI", 10F);
            foreach (Control c in form.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = ThemeColors.Primary;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
                    ApplyRoundedCorners(btn, 6);
                }
                else if (c is TextBox tb)
                {
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    tb.BackColor = ThemeColors.InputBackground;
                    tb.ForeColor = ThemeColors.TextPrimary;
                    tb.Font = new Font("Segoe UI", 10F);
                    ApplyRoundedCorners(tb, 6);
                }
                // ...add more control types as needed...
            }
        }

        // Modern style for forms
        public static void StyleForm(Form form)
        {
            form.BackColor = ThemeColors.Background;
            form.Font = new Font("Segoe UI", 10F);
        }

        // Enable dragging of borderless forms via a control (e.g., panel)
        public static void EnableFormDrag(Form form, Control dragControl)
        {
            Point dragCursorPoint = Point.Empty;
            Point dragFormPoint = Point.Empty;
            bool isDragging = false;

            dragControl.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    dragCursorPoint = Cursor.Position;
                    dragFormPoint = form.Location;
                }
            };
            dragControl.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                    form.Location = Point.Add(dragFormPoint, new Size(dif));
                }
            };
            dragControl.MouseUp += (s, e) =>
            {
                isDragging = false;
            };
        }

        // Modern style for buttons
        public static void StyleButton(Button btn, int borderRadius = 6)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = ThemeColors.Primary;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            ApplyRoundedCorners(btn, borderRadius);
        }
    }

    // ...existing code...

    internal static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }

    // Class for custom rounded button (optional enhancement)
    public class RoundButton : Button
    {
        private int borderRadius = 20;
        public int BorderRadius 
        { 
            get => borderRadius;
            set { borderRadius = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            grPath.AddArc(this.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            grPath.AddArc(this.Width - borderRadius, this.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            grPath.AddArc(0, this.Height - borderRadius, borderRadius, borderRadius, 90, 90);

            this.Region = new Region(grPath);
            base.OnPaint(pevent);
        }
    }
}

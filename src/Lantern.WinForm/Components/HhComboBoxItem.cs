namespace Lantern.WinForm.Components
{
    /// <summary>
    /// 自定义下拉框数据项
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class HhComboBoxItem<TKey, TValue>
    {
        public const string VALUE_MEMBER = "Key";
        public const string DISPLAY_MEMBER = "Value";

        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public HhComboBoxItem()
        { }

        public HhComboBoxItem(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
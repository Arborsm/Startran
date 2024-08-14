using AntdUI;
using Message = AntdUI.Message;

namespace Startran.Misc
{
    /// <summary>Message 全局提示</summary>
    /// <remarks>全局展示操作反馈信息。</remarks>
    internal static class MessageTool
    {
        private const TAlignFrom AlignFrom = TAlignFrom.Bottom;

        private static Message.Config Message(Form form, string text, TType type, Font? font = null, int? autoClose = null)
        {
            return new Message.Config(form, text, type, font, autoClose)
            {
                Align = AlignFrom
            };
        }

        /// <summary>成功提示</summary>
        /// <param name="form">窗口</param>
        /// <param name="text">提示内容</param>
        /// <param name="font">字体</param>
        /// <param name="autoClose">自动关闭时间（秒）0等于不关闭</param>
        public static void Success(Form form, string text, Font? font = null, int? autoClose = null)
        {
            Message(form, text, TType.Success, font, autoClose).open();
        }

        /// <summary>成功提示, 关闭窗口</summary>
        /// <param name="form">窗口</param>
        /// <param name="text">提示内容</param>
        /// <param name="font">字体</param>
        /// <param name="autoClose">自动关闭时间（秒）0等于不关闭</param>
        public static void SuccessWithBreak(Form form, string text, Font? font = null, int? autoClose = null)
        {
            AntdUI.Message.close_all();
            Success(form, text, font, autoClose);
        }

        /// <summary>信息提示</summary>
        /// <param name="form">窗口</param>
        /// <param name="text">提示内容</param>
        /// <param name="font">字体</param>
        /// <param name="autoClose">自动关闭时间（秒）0等于不关闭</param>
        public static void Info(Form form, string text, Font? font = null, int? autoClose = null)
        {
            Message(form, text, TType.Info, font, autoClose).open();
        }

        /// <summary>警告提示</summary>
        /// <param name="form">窗口</param>
        /// <param name="text">提示内容</param>
        /// <param name="font">字体</param>
        /// <param name="autoClose">自动关闭时间（秒）0等于不关闭</param>
        public static void Warn(Form form, string text, Font? font = null, int? autoClose = null)
        {
            Message(form, text, TType.Warn, font, autoClose).open();
        }

        /// <summary>失败提示</summary>
        /// <param name="form">窗口</param>
        /// <param name="text">提示内容</param>
        /// <param name="font">字体</param>
        /// <param name="autoClose">自动关闭时间（秒）0等于不关闭</param>
        public static void Error(Form form, string text, Font? font = null, int? autoClose = null)
        {
            Message(form, text, TType.Error, font, autoClose).open();
        }

        /// <summary>加载提示</summary>
        /// <param name="form">窗口</param>
        /// <param name="text">提示内容</param>
        /// <param name="call">耗时任务</param>
        /// <param name="font">字体</param>
        /// <param name="autoClose">自动关闭时间（秒）0等于不关闭</param>
        public static void Loading(
            Form form,
            string text,
            Action<Message.Config> call,
            Font? font = null,
            int? autoClose = null)
        {
            new Message.Config(form, text, TType.None, font, autoClose)
            {
                Align = AlignFrom,
                Call = call
            }.open();
        }
    }
}

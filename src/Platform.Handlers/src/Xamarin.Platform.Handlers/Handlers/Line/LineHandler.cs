﻿#if NETSTANDARD
using NativeView = System.Object;
#else
using NativeView = Xamarin.Platform.NativeLine;
#endif

namespace Xamarin.Platform.Handlers
{
    public partial class LineHandler : AbstractViewHandler<ILine, NativeView>
	{
		public static PropertyMapper<ILine, LineHandler> LineMapper = new PropertyMapper<ILine, LineHandler>(ShapeHandler.ShapeMapper)
		{
			[nameof(ILine.X1)] = MapX1,
			[nameof(ILine.Y1)] = MapY1,
			[nameof(ILine.X2)] = MapX2,
			[nameof(ILine.Y2)] = MapY2
		};

		public static void MapX1(LineHandler handler, ILine line)
		{
			handler.TypedNativeView.UpdateX1(line);
		}

		public static void MapY1(LineHandler handler, ILine line)
		{
			handler.TypedNativeView.UpdateY1(line);
		}

		public static void MapX2(LineHandler handler, ILine line)
		{
			handler.TypedNativeView.UpdateX2(line);
		}

		public static void MapY2(LineHandler handler, ILine line)
		{
			handler.TypedNativeView.UpdateY2(line);
		}

#if MONOANDROID
		protected override NativeView CreateView() => new NativeView(Context);
#else
		protected override NativeView CreateView() => new NativeView();
#endif

		public LineHandler() : base(LineMapper)
		{

		}

		public LineHandler(PropertyMapper mapper) : base(mapper ?? LineMapper)
		{

		}
	}
}
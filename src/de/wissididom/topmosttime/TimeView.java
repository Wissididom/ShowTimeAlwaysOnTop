package de.wissididom.topmosttime;

import java.awt.Color;
import java.awt.FontMetrics;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.geom.AffineTransform;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.Timer;
import java.util.TimerTask;

import javax.swing.ImageIcon;
import javax.swing.JFrame;

public class TimeView extends JFrame {
	private static final long serialVersionUID = 1L;
	
	private String sTime = "";
	
	public String getTime() {
		return this.sTime;
	}
	
	public TimeView setTime(String time) {
		this.sTime = time;
		return this;
	}
	
	public TimeView() {
		this.setTitle("Show Time Always On Top");
		this.setAlwaysOnTop(true);
		this.setBackground(Color.WHITE);
		this.setBounds(100, 100, 672, 464);
		this.setLayout(null);
		this.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.setUndecorated(true);
		this.setIconImage(new ImageIcon(ClassLoader.getSystemResource("de/wissididom/topmosttime/assets")).getImage());
		
		new Timer().scheduleAtFixedRate(new TimerTask() {
			@Override
			public void run() {
				Calendar c = GregorianCalendar.getInstance();
				int hour = c.get(Calendar.HOUR_OF_DAY);
				int minute = c.get(Calendar.MINUTE);
				String hourStr = String.valueOf(hour);
				String minuteStr = String.valueOf(minute);
				if (hour < 10) hourStr = "0" + hourStr;
				if (minute < 10) minuteStr = "0" + minuteStr;
				String oldTime = TimeView.this.sTime;
				TimeView.this.sTime = hourStr + ":" + minuteStr;
				if (!oldTime.equals(TimeView.this.sTime)) TimeView.this.repaint();
			}
		}, 0, 1000);
	}
	
	@Override
	public void paint(Graphics g) {
		super.paint(g);
		Graphics2D g2d = (Graphics2D) g;
		FontMetrics fm = g2d.getFontMetrics();
		GlyphVector gv = g.getFont().createGlyphVector(g2d.getFontRenderContext(), this.sTime);
		Shape shape = gv.getOutline();
		AffineTransform at = new AffineTransform();
		at.translate(10, 10 + fm.getAscent() - fm.getDescent());
		Shape transformedShape = at.createTransformedShape(shape);
		this.setShape(transformedShape);
	}
}

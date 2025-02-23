package de.wissididom.topmosttime;

import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.Point;
import java.awt.event.ActionEvent;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JSlider;
import javax.swing.SwingUtilities;
import javax.swing.event.ChangeEvent;

public class TopMostTimeMain extends JFrame {
	private static final long serialVersionUID = 1L;
	
	private JPanel dragArea = new JPanel();
	private JSlider tbOpacity = new JSlider();
	private JSlider tbSize = new JSlider();
	
	private final TimeView Tv = new TimeView();
	private int X, Y;
	private boolean TimeShown = false;
	
	public static void main(String[] args) {
		SwingUtilities.invokeLater(() -> {
			TopMostTimeMain tmp = new TopMostTimeMain();
			tmp.setVisible(true);
			try {
				tmp.LoadConfig();
			} catch (IOException e) {
				e.printStackTrace();
			}
		});
	}
	
	public TopMostTimeMain() {
		this.setTitle("Show Time Always On Top");
		this.setBounds(100, 100, 827, 700);
		this.setLayout(null);
		this.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent e) {
				StringBuilder settings = new StringBuilder();
				settings.append("TimeX=").append(TopMostTimeMain.this.Tv.getLocation().x).append('\n');
				settings.append("TimeY=").append(TopMostTimeMain.this.Tv.getLocation().y).append('\n');
				settings.append("TimeFont=").append(Tv.getFont().getFamily()).append('\n');
				Color tvBackground = TopMostTimeMain.this.Tv.getBackground();
				if (tvBackground != null) {
					settings.append("TimeColorR=").append(tvBackground.getRed()).append('\n');
					settings.append("TimeColorG=").append(tvBackground.getGreen()).append('\n');
					settings.append("TimeColorB=").append(tvBackground.getBlue()).append('\n');
				}
				settings.append("TimeShown=").append(TopMostTimeMain.this.TimeShown).append('\n');
				settings.append("Transparency=").append(TopMostTimeMain.this.tbOpacity.getValue()).append('\n');
				settings.append("Size=").append(TopMostTimeMain.this.tbSize.getValue()).append('\n');
				settings.append("X=").append(TopMostTimeMain.this.getLocation().x).append('\n');
				settings.append("Y=").append(TopMostTimeMain.this.getLocation().y).append('\n');
				try (PrintWriter pw = new PrintWriter("config.txt")) {
					pw.println(settings.toString());
				} catch (IOException ex) {
					ex.printStackTrace();
				}
				System.exit(0);
			}
		});
		
		JButton btnShow = new JButton("Show");
		btnShow.addActionListener((ActionEvent e) -> {
			TopMostTimeMain.this.Tv.setVisible(true);
			TopMostTimeMain.this.TimeShown = true;
		});
		
		JButton btnHide = new JButton("Hide");
		btnHide.addActionListener((ActionEvent e) -> {
			TopMostTimeMain.this.Tv.setVisible(false);
			TopMostTimeMain.this.TimeShown = false;
		});
		
		JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.CENTER));
		buttonPanel.setBounds(this.getWidth() / 2 - 500/*buttonPanel.getWidth()*/ / 2, 15, 500, 30);
		buttonPanel.add(btnShow);
		buttonPanel.add(btnHide);
		
		this.tbOpacity.setBounds(130, 47, 682, 45);
		this.tbOpacity.setMinimum(0);
		this.tbOpacity.setMaximum(100);
		this.tbOpacity.setValue(100);
		this.tbOpacity.addChangeListener((ChangeEvent e) -> {
			TopMostTimeMain.this.Tv.setOpacity(this.tbOpacity.getValue() / 100F);
		});
		
		this.tbSize.setBounds(130, 106, 682, 45);
		this.tbSize.setMinimum(10);
		this.tbSize.setMaximum(100);
		this.tbSize.setValue(10);
		this.tbSize.addChangeListener((ChangeEvent e) -> {
			Font f = TopMostTimeMain.this.Tv.getFont();
			TopMostTimeMain.this.Tv.setFont(new Font(f.getFamily(), f.getStyle(), TopMostTimeMain.this.tbSize.getValue()));
		});
		
		JLabel lblOpacity = new JLabel("Transparency");
		lblOpacity.setBounds(19, 53, 100, 30);
		JLabel lblSize = new JLabel("Size");
		lblSize.setBounds(36, 112, 100, 30);
		
		MouseAdapter dragAreaMouseAdapter = new MouseAdapter() {
			@Override
			public void mousePressed(MouseEvent e) {
				Point p = e.getPoint();
				TopMostTimeMain.this.X = p.x - TopMostTimeMain.this.Tv.getX();
				TopMostTimeMain.this.Y = p.y - TopMostTimeMain.this.Tv.getY();
			}
			@Override
			public void mouseDragged(MouseEvent e) {
				if (SwingUtilities.isLeftMouseButton(e)) {
					Point p = e.getPoint();
					TopMostTimeMain.this.Tv.setLocation(p.x - X, p.y - Y);
				}
			}
		};
		
		this.dragArea.setBounds(15, 205, 797, 443);
		this.dragArea.setBackground(Color.BLACK);
		this.dragArea.addMouseListener(dragAreaMouseAdapter);
		this.dragArea.addMouseMotionListener(dragAreaMouseAdapter);
		
		this.add(this.dragArea);
		this.add(buttonPanel);
		this.add(tbOpacity);
		this.add(tbSize);
		this.add(lblOpacity);
		this.add(lblSize);
	}
	
	private static String[] ReadAllLines(File f) throws IOException {
		BufferedReader br = null;
		try {
			br = new BufferedReader(new FileReader(f));
			List<String> lines = new ArrayList<String>();
			String line = null;
			while ((line = br.readLine()) != null) {
				lines.add(line);
			}
			return lines.toArray(new String[lines.size()]);
		} catch(IOException e) {
			throw e;
		} finally {
			if (br != null) br.close();
		}
	}
	
	private void LoadConfig() throws IOException {
		File f = new File("config.txt");
		if (!f.exists() || f.isDirectory()) return;
		String[] lines = ReadAllLines(f);
		for (String line : lines) {
			if (line.contains("=")) {
				String key = line.substring(0, line.indexOf('='));
				String value = line.substring(line.indexOf('=') + 1);
				switch (key) {
					case "TimeX": {
						this.Tv.setLocation(Integer.parseInt(value), this.Tv.getLocation().y);
						break;
					} case "TimeY": {
						this.Tv.setLocation(this.Tv.getLocation().x, Integer.parseInt(value));
						break;
					} case "TimeFont": {
						Font font = this.Tv.getFont();
						if (font == null) {
							this.Tv.setFont(new Font(value, Font.PLAIN, 10));
						}  else {
							this.Tv.setFont(new Font(value, font.getStyle(), font.getSize()));
						}
						break;
					} case "TimeColorR": {
						Color background = this.Tv.getBackground();
						if (background == null) {
							background = Color.WHITE;
						}
						this.Tv.setBackground(new Color(Integer.parseInt(value), background.getGreen(), background.getBlue()));
						break;
					} case "TimeColorG": {
						Color background = this.Tv.getBackground();
						if (background == null) {
							background = Color.WHITE;
						}
						this.Tv.setBackground(new Color(background.getRed(), Integer.parseInt(value), background.getBlue()));
						break;
					} case "TimeColorB": {
						Color background = this.Tv.getBackground();
						if (background == null) {
							background = Color.WHITE;
						}
						this.Tv.setBackground(new Color(background.getRed(), background.getGreen(), Integer.parseInt(value)));
						break;
					} case "TimeShown": {
						if (Boolean.parseBoolean(value)) {
							this.Tv.setVisible(true);
							this.TimeShown = true;
						} else {
							this.Tv.setVisible(false);
							this.TimeShown = false;
						}
						break;
					} case "Transparency": {
						this.tbOpacity.setValue(Integer.parseInt(value));
						this.Tv.setOpacity(Integer.parseInt(value) / 100F);
						break;
					} case "Size": {
						this.tbSize.setValue(Integer.parseInt(value));
						Font font = this.Tv.getFont();
						if (font == null) {
							this.Tv.setFont(new Font("Arial", Font.PLAIN, Integer.parseInt(value)));
						} else {
							this.Tv.setFont(new Font(font.getFamily(), font.getStyle(), Integer.parseInt(value)));
						}
						break;
					} case "X": {
						this.setLocation(Integer.parseInt(value), this.getLocation().y);
						break;
					} case "Y": {
						this.setLocation(this.getLocation().x, Integer.parseInt(value));
						break;
					}
				}
			}
		}
	}
}

// Fourier.java (C) 2001 by Paul Falstad, www.falstad.com

import java.io.InputStream;
import java.awt.*;
import java.awt.image.ImageProducer;
import java.applet.Applet;
import java.applet.AudioClip;
import java.util.Vector;
import java.util.Hashtable;
import java.util.Enumeration;
import java.io.File;
import java.net.URL;
import java.util.Random;
import java.awt.image.MemoryImageSource;
import java.lang.Math;
import java.awt.event.*;
import sun.audio.*;

class FourierCanvas extends Canvas {
    FourierFrame pg;
    FourierCanvas(FourierFrame p) {
	pg = p;
    }
    public Dimension getPreferredSize() {
	return new Dimension(300,400);
    }
    public void update(Graphics g) {
	pg.updateFourier(g);
    }
    public void paint(Graphics g) {
	pg.updateFourier(g);
    }
};

class FourierLayout implements LayoutManager {
    public FourierLayout() {}
    public void addLayoutComponent(String name, Component c) {}
    public void removeLayoutComponent(Component c) {}
    public Dimension preferredLayoutSize(Container target) {
	return new Dimension(500, 500);
    }
    public Dimension minimumLayoutSize(Container target) {
	return new Dimension(100,100);
    }
    public void layoutContainer(Container target) {
	int barwidth = 0;
	int i;
	for (i = 1; i < target.getComponentCount(); i++) {
	    Component m = target.getComponent(i);
	    if (m.isVisible()) {
		Dimension d = m.getPreferredSize();
		if (d.width > barwidth)
		    barwidth = d.width;
	    }
	}
	Insets insets = target.insets();
	int targetw = target.size().width - insets.left - insets.right;
	int cw = targetw-barwidth;
	int targeth = target.size().height - (insets.top+insets.bottom);
	target.getComponent(0).move(insets.left, insets.top);
	target.getComponent(0).resize(cw, targeth);
	cw += insets.left;
	int h = insets.top;
	for (i = 1; i < target.getComponentCount(); i++) {
	    Component m = target.getComponent(i);
	    if (m.isVisible()) {
		Dimension d = m.getPreferredSize();
		if (m instanceof Scrollbar)
		    d.width = barwidth;
		if (m instanceof Label) {
		    h += d.height/5;
		    d.width = barwidth;
		}
		m.move(cw, h);
		m.resize(d.width, d.height);
		h += d.height;
	    }
	}
    }
};


public class Fourier extends Applet {
    FourierFrame ff;
    void destroyFrame() {
	if (ff != null)
	    ff.dispose();
	ff = null;
    }
    public void init() {
	ff = new FourierFrame(this);
	ff.init();
    }
    public void destroy() {
	if (ff != null)
	    ff.dispose();
	ff = null;
    }
};

class FourierFrame extends Frame
  implements ComponentListener, ActionListener, AdjustmentListener,
             MouseMotionListener, MouseListener {
    
    Thread engine = null;

    Dimension winSize;
    Image dbimage;
    
    Random random;
    public static final int sampleCount = 720;
    public static final int halfSampleCount = sampleCount/2;
    public static final double halfSampleCountFloat = sampleCount/2;
    
    public String getAppletInfo() {
	return "Fourier Series by Paul Falstad";
    }

    FourierFrame(Fourier a) {
	super("Fourier Series Applet");
	applet = a;
    }
    Fourier applet;
    Button sineButton;
    Button rectButton;
    Button fullRectButton;
    Button triangleButton;
    Button sawtoothButton;
    Button squareButton;
    Button noiseButton;
    Button blankButton;
    Button clipButton;
    Button resampleButton;
    Button quantizeButton;
    Button playButton;
    Scrollbar termBar;
    Scrollbar freqBar;
    double magcoef[];
    double phasecoef[];
    static final double pi = 3.14159265358979323846;
    static final double step = 2 * pi / sampleCount;
    double func[];
    int maxTerms = 160;
    int selectedCoef;
    static final int SEL_NONE = 0;
    static final int SEL_FUNC = 1;
    static final int SEL_MAG = 2;
    static final int SEL_PHASE = 3;
    int selection;
    int dragX, dragY;
    boolean dragging;

    static final int to_ulaw[] = {
	0,    0,    0,    0,    0,    1,    1,    1,
	1,    2,    2,    2,    2,    3,    3,    3,
	3,    4,    4,    4,    4,    5,    5,    5,
	5,    6,    6,    6,    6,    7,    7,    7,
	7,    8,    8,    8,    8,    9,    9,    9,
	9,   10,   10,   10,   10,   11,   11,   11,
	11,   12,   12,   12,   12,   13,   13,   13,
	13,   14,   14,   14,   14,   15,   15,   15,
	15,   16,   16,   17,   17,   18,   18,   19,
	19,   20,   20,   21,   21,   22,   22,   23,
	23,   24,   24,   25,   25,   26,   26,   27,
	27,   28,   28,   29,   29,   30,   30,   31,
	31,   32,   33,   34,   35,   36,   37,   38,
	39,   40,   41,   42,   43,   44,   45,   46,
	47,   49,   51,   53,   55,   57,   59,   61,
	63,   66,   70,   74,   78,   84,   92,  104,
	254,  231,  219,  211,  205,  201,  197,  193,
	190,  188,  186,  184,  182,  180,  178,  176,
	175,  174,  173,  172,  171,  170,  169,  168,
	167,  166,  165,  164,  163,  162,  161,  160,
	159,  159,  158,  158,  157,  157,  156,  156,
	155,  155,  154,  154,  153,  153,  152,  152,
	151,  151,  150,  150,  149,  149,  148,  148,
	147,  147,  146,  146,  145,  145,  144,  144,
	143,  143,  143,  143,  142,  142,  142,  142,
	141,  141,  141,  141,  140,  140,  140,  140,
	139,  139,  139,  139,  138,  138,  138,  138,
	137,  137,  137,  137,  136,  136,  136,  136,
	135,  135,  135,  135,  134,  134,  134,  134,
	133,  133,  133,  133,  132,  132,  132,  132,
	131,  131,  131,  131,  130,  130,  130,  130,
	129,  129,  129,  129,  128,  128,  128,  128
    };

    int getrand(int x) {
	int q = random.nextInt();
	if (q < 0) q = -q;
	return q % x;
    }
    FourierCanvas cv;

    public void init() {
	selectedCoef = -1;
	magcoef = new double[maxTerms];
	phasecoef = new double[maxTerms];
	func = new double[sampleCount+1];
	setLayout(new FourierLayout());
	cv = new FourierCanvas(this);
	cv.addComponentListener(this);
	cv.addMouseMotionListener(this);
	cv.addMouseListener(this);
	add(cv);
	add(sineButton = new Button("Sine"));
	sineButton.addActionListener(this);
	add(triangleButton = new Button("Triangle"));
	triangleButton.addActionListener(this);
	add(sawtoothButton = new Button("Sawtooth"));
	sawtoothButton.addActionListener(this);
	add(squareButton = new Button("Square"));
	squareButton.addActionListener(this);
	add(noiseButton = new Button("Noise"));
	noiseButton.addActionListener(this);
	add(clipButton = new Button("Clip"));
	clipButton.addActionListener(this);
	add(resampleButton = new Button("Resample"));
	resampleButton.addActionListener(this);
	add(quantizeButton = new Button("Quantize"));
	quantizeButton.addActionListener(this);
	add(rectButton = new Button("Rectify"));
	rectButton.addActionListener(this);
	add(fullRectButton = new Button("Full Rectify"));
	fullRectButton.addActionListener(this);
	add(playButton = new Button("Play"));
	playButton.addActionListener(this);
	add(blankButton = new Button("Clear"));
	blankButton.addActionListener(this);
	add(new Label("Number of Terms", Label.CENTER));
	add(termBar = new Scrollbar(Scrollbar.HORIZONTAL, 30, 1, 1, maxTerms));
	termBar.addAdjustmentListener(this);
	add(new Label("Playing Frequency", Label.CENTER));
	add(freqBar = new Scrollbar(Scrollbar.HORIZONTAL, 50, 1, 0, 100));
	freqBar.addAdjustmentListener(this);
	add(new Label("http://www.falstad.com", Label.CENTER));
	random = new Random();
	reinit();
	cv.setBackground(Color.black);
	cv.setForeground(Color.lightGray);
	resize(500, 500);
	handleResize();
	show();
    }

    void reinit() {
	doSawtooth();
    }
    
    void handleResize() {
        Dimension d = winSize = cv.getSize();
	if (winSize.width == 0)
	    return;
	dbimage = createImage(d.width, d.height);
    }

    void doSawtooth() {
	int x;
	for (x = 0; x != sampleCount; x++)
	    func[x] = (x-sampleCount/2) / halfSampleCountFloat;
	func[sampleCount] = func[0];
	transform();
    }

    void doTriangle() {
	int x;
	for (x = 0; x != halfSampleCount; x++) {
	    func[x] = (x*2-halfSampleCount) / halfSampleCountFloat;
	    func[x+halfSampleCount] =
		((halfSampleCount-x)*2-halfSampleCount) / halfSampleCountFloat;
	}
	func[sampleCount] = func[0];
	transform();
    }

    void doSine() {
	int x;
	for (x = 0; x != sampleCount; x++) {
	    func[x] = java.lang.Math.sin((x-halfSampleCount)*step);
	}
	func[sampleCount] = func[0];
	transform();
    }

    void doRect() {
	int x;
	for (x = 0; x != sampleCount; x++)
	    if (func[x] < 0)
		func[x] = 0;
	func[sampleCount] = func[0];
	transform();
    }

    void doFullRect() {
	int x;
	for (x = 0; x != sampleCount; x++)
	    if (func[x] < 0)
		func[x] = -func[x];
	func[sampleCount] = func[0];
	transform();
    }

    void doSquare() {
	int x;
	for (x = 0; x != halfSampleCount; x++) {
	    func[x] = -1;
	    func[x+halfSampleCount] = 1;
	}
	func[sampleCount] = func[0];
	transform();
    }

    void doNoise() {
	int x;
	int blockSize = 3;
	for (x = 0; x != sampleCount/blockSize; x++) {
	    double q = java.lang.Math.random() *2 - 1;
	    int i;
	    for (i = 0; i != blockSize; i++)
		func[x*blockSize+i] = q;
	}
	func[sampleCount] = func[0];
	transform();
    }

    void doBlank() {
	int x;
	for (x = 0; x <= sampleCount; x++)
	    func[x] = 0;
	transform();
    }

    void doSetFunc() {
	int i;
	int periodWidth = winSize.width / 3;
	for (i = 0; i != sampleCount+1; i++) {
	    int x = periodWidth * i / sampleCount;
	    int j;
	    double dy = 0;
	    int terms = termBar.getValue();
	    for (j = 0; j != terms; j++) {
		dy += magcoef[j] * java.lang.Math.cos(
			    step*(i-halfSampleCount)*j+phasecoef[j]);
	    }
	    func[i] = dy;
	}
	transform();
    }

    void doClip() {
	int x;
	double mult = 1.2;
	for (x = 0; x != sampleCount; x++) {
	    func[x] *= mult;
	    if (func[x] > 1)
		func[x] = 1;
	    if (func[x] < -1)
		func[x] = -1;
	}
	func[sampleCount] = func[0];
	transform();
    }

    void doResample() {
	int chunksize = 60;
	int x, i;
	for (x = 0; x != sampleCount; x += chunksize) {
	    for (i = 1; i != chunksize; i++)
		func[x+i] = func[x];
	}
	func[sampleCount] = func[0];
	transform();
    }

    void doQuantize() {
	int x;
	for (x = 0; x != sampleCount; x++) {
	    func[x] = java.lang.Math.round(func[x]*2)/2.;
	}
	func[sampleCount] = func[0];
	transform();
    }

    static int freqs[] = {
	25, 32, 40, 50, 64, 80,
	100, 125, 160, 200, 250, 320,
	400, 500, 800, 1000, 1600, 2000
    };

    int getFreq() {
	return (int) (27.5*java.lang.Math.exp(freqBar.getValue()*.04158883084));
    }

    void doPlay() {
	doSetFunc();
	byte b[] = new byte[16000];
	int i;
	double mx = 0;
	for (i = 0; i != sampleCount; i++) {
	    if (func[i] > mx) mx = func[i];
	    if (func[i] < -mx) mx = -func[i];
	}
	double mult = 127/mx;
	int pd = 8000/getFreq();
	double f = 720./pd;
	for (i = 0; i != 16000; i++) {
	    int x = (int) (.5 + func[(int) ((i % pd)*f)] * mult);
	    b[i] = (byte) to_ulaw[x+128];
	}
	AudioDataStream ads = new AudioDataStream(new AudioData(b));
	AudioPlayer.player.start(ads);
	cv.repaint();
    }

    void transform() {
	int x, y;
	double epsilon = .00001;
	for (y = 0; y != maxTerms; y++) {
	    double coef = 0;
	    for (x = 0; x != sampleCount+1; x++) {
		int simp = (x == 0 || x == sampleCount) ? 1 : ((x&1)+1)*2;
		double s = java.lang.Math.cos(step*(x-halfSampleCount)*y);
		coef += s*func[x]*simp;
	    }
	    // simpson = 2pi/(3*sampleCount) (f(0) + 4f(1) + 2f(2) ...)
	    // integral(...)/pi
	    // result = coef * 2/3*sampleCount
	    double acoef = coef*(2.0/(3.0*sampleCount));
	    //System.out.print("acoef " + y + " " + coef + "\n");
	    coef = 0;
	    for (x = 0; x != sampleCount+1; x++) {
		int simp = (x == 0 || x == sampleCount) ? 1 : ((x&1)+1)*2;
		double s = java.lang.Math.sin(step*(x-halfSampleCount)*y);
		coef += s*func[x]*simp;
	    }
	    double bcoef = coef*(2.0/(3.0*sampleCount));
	    if (acoef < epsilon && acoef > -epsilon) acoef = 0;
	    if (bcoef < epsilon && bcoef > -epsilon) bcoef = 0;
	    if (y == 0) {
		magcoef[0] = acoef / 2;
		phasecoef[0] = 0;
	    } else {
		magcoef[y] = java.lang.Math.sqrt(acoef*acoef+bcoef*bcoef);
		phasecoef[y] = java.lang.Math.atan2(-bcoef, acoef);
	    }
	    // System.out.print("phasecoef " + phasecoef[y] + "\n");
	}
    }

    int getPanelHeight() { return winSize.height / 3; }

    void centerString(Graphics g, String s, int y) {
	FontMetrics fm = g.getFontMetrics();
        g.drawString(s, (winSize.width-fm.stringWidth(s))/2, y);
    }

    public void paint(Graphics g) {
	cv.repaint();
    }

    public void updateFourier(Graphics realg) {
	Graphics g = dbimage.getGraphics();
	if (winSize == null || winSize.width == 0)
	    return;
	Color gray1 = new Color(76,  76,  76);
	Color gray2 = new Color(127, 127, 127);
	g.setColor(cv.getBackground());
	g.fillRect(0, 0, winSize.width, winSize.height);
	g.setColor(cv.getForeground());
	int i;
	int ox = -1, oy = -1;
	int panelHeight = getPanelHeight();
	int midy = panelHeight / 2;
	int halfPanel = panelHeight / 2;
	int periodWidth = winSize.width / 3;
	double ymult = .75 * halfPanel;
	for (i = -1; i <= 1; i++) {
	    g.setColor((i == 0) ? gray2 : gray1);
	    g.drawLine(0,             midy+(i*(int) ymult),
		       winSize.width, midy+(i*(int) ymult));
	}
	for (i = 2; i <= 4; i++) {
	    g.setColor((i == 3) ? gray2 : gray1);
	    g.drawLine(periodWidth*i/2, midy-(int) ymult,
		       periodWidth*i/2, midy+(int) ymult);
	}
	g.setColor(Color.white);
	if (!(dragging && selection != SEL_FUNC)) {
	    for (i = 0; i != sampleCount+1; i++) {
		int x = periodWidth * i / sampleCount;
		int y = midy - (int) (ymult * func[i]);
		if (ox != -1) {
		    g.drawLine(ox, oy, x, y);
		    g.drawLine(ox+periodWidth, oy,   x+periodWidth,   y);
		    g.drawLine(ox+periodWidth*2, oy, x+periodWidth*2, y);
		}
		ox = x;
		oy = y;
	    }
	}
	int terms = termBar.getValue();
	if (!(dragging && selection == SEL_FUNC)) {
	    g.setColor(Color.red);
	    ox = -1;
	    for (i = 0; i != sampleCount+1; i++) {
		int x = periodWidth * i / sampleCount;
		int j;
		double dy = 0;
		for (j = 0; j != terms; j++) {
		    dy += magcoef[j] * java.lang.Math.cos(
                        step*(i-halfSampleCount)*j+phasecoef[j]);
		}
		int y = midy - (int) (ymult * dy);
		if (ox != -1) {
		    g.drawLine(ox, oy, x, y);
		    g.drawLine(ox+periodWidth, oy,   x+periodWidth,   y);
		    g.drawLine(ox+periodWidth*2, oy, x+periodWidth*2, y);
		}
		ox = x;
		oy = y;
	    }
	}
	if (selectedCoef != -1 && !dragging) {
	    g.setColor(Color.yellow);
	    ox = -1;
	    ymult *= magcoef[selectedCoef];
	    double phase = phasecoef[selectedCoef];
	    int x;
	    double n = selectedCoef*2*pi/periodWidth;
	    int dx = periodWidth/2;
	    for (i = 0; i != sampleCount+1; i++) {
		x = periodWidth * i / sampleCount;
		double dy = java.lang.Math.cos(
		     step*(i-halfSampleCount)*selectedCoef+phase);
		int y = midy - (int) (ymult * dy);
		if (ox != -1) {
		    g.drawLine(ox, oy, x, y);
		    g.drawLine(ox+periodWidth, oy,   x+periodWidth,   y);
		    g.drawLine(ox+periodWidth*2, oy, x+periodWidth*2, y);
		}
		ox = x;
		oy = y;
	    }
	    if (selectedCoef > 0) {
		int f = getFreq() * selectedCoef;
		centerString(g, getFreq() * selectedCoef +
			     ((f > 4000) ? " Hz (aliased)" : " Hz"),
			     panelHeight);
	    }
	}
	int termWidth = getTermWidth();
	ymult = 1.2 * halfPanel;
	midy = ((panelHeight * 3) / 2) + (int) ymult/2;
	g.setColor(Color.white);
	centerString(g, "Magnitudes", (int) (panelHeight*1.16));
	centerString(g, "Phases", (int) (panelHeight*2.10));
	g.setColor(gray2);
	g.drawLine(0, midy, winSize.width, midy);
	g.setColor(gray1);
	g.drawLine(0, midy-(int)ymult, winSize.width, midy-(int) ymult);
	int dotSize = termWidth-3;
	for (i = 0; i != terms; i++) {
	    int t = termWidth * i + termWidth/2;
	    int y = midy - (int) (magcoef[i]*ymult);
	    g.setColor(i == selectedCoef ? Color.yellow : Color.white);
	    g.drawLine(t, midy, t, y);
	    g.fillOval(t-dotSize/2, y-dotSize/2, dotSize, dotSize);
	}
	ymult = .75 * halfPanel;
	midy = ((panelHeight * 5) / 2);
	for (i = -2; i <= 2; i++) {
	    g.setColor((i == 0) ? gray2 : gray1);
	    g.drawLine(0,             midy+(i*(int) ymult)/2,
		       winSize.width, midy+(i*(int) ymult)/2);
	}
	ymult /= pi;
	for (i = 0; i != terms; i++) {
	    int t = termWidth * i + termWidth/2;
	    int y = midy - (int) (phasecoef[i]*ymult);
	    g.setColor(i == selectedCoef ? Color.yellow : Color.white);
	    g.drawLine(t, midy, t, y);
	    g.fillOval(t-dotSize/2, y-dotSize/2, dotSize, dotSize);
	}
	realg.drawImage(dbimage, 0, 0, this);
    }

    int getTermWidth() {
	int terms = termBar.getValue();
	int termWidth = winSize.width / terms;
	int maxTermWidth = winSize.width/30;
	if (termWidth > maxTermWidth)
	    termWidth = maxTermWidth;
	termWidth &= ~1;
	return termWidth;
    }

    void edit(MouseEvent e) {
	if (selection == SEL_NONE)
	    return;
	int x = e.getX();
	int y = e.getY();
	switch (selection) {
	case SEL_MAG: editMag(x, y); break;
	case SEL_FUNC: editFunc(x, y); break;
	case SEL_PHASE: editPhase(x, y); break;
	}
    }

    void editMag(int x, int y) {
	if (selectedCoef == -1)
	    return;
	int panelHeight = getPanelHeight();
	double ymult = 1.2 * panelHeight/2;
	double midy = ((panelHeight * 3) / 2) + (int) ymult/2;
	double coef = -(y-midy) / ymult;
	if (selectedCoef > 0) {
	    if (coef < 0)
		coef = 0;
	} else if (coef < -1)
	    coef = -1;
	if (coef > 1)
	    coef = 1;
	if (magcoef[selectedCoef] == coef)
	    return;
	magcoef[selectedCoef] = coef;
	cv.repaint();
    }

    void editFunc(int x, int y) {
	if (dragX == x) {
	    editFuncPoint(x, y);
	    dragY = y;
	} else {
	    // need to draw a line from old x,y to new x,y and
	    // call editFuncPoint for each point on that line.  yuck.
	    int x1 = (x < dragX) ? x : dragX;
	    int y1 = (x < dragX) ? y : dragY;
	    int x2 = (x > dragX) ? x : dragX;
	    int y2 = (x > dragX) ? y : dragY;
	    dragX = x;
	    dragY = y;
	    for (x = x1; x <= x2; x++) {
		y = y1+(y2-y1)*(x-x1)/(x2-x1);
		editFuncPoint(x, y);
	    }
	}
    }
    
    void editFuncPoint(int x, int y) {
	int panelHeight = getPanelHeight();
	int midy = panelHeight / 2;
	int halfPanel = panelHeight / 2;
	int periodWidth = winSize.width / 3;
	double ymult = .75 * halfPanel;
	int lox = (x % periodWidth) * sampleCount / periodWidth;
	int hix = (((x % periodWidth)+1) * sampleCount / periodWidth)-1;
	double val = (midy - y) / ymult;
	if (val > 1)
	    val = 1;
	if (val < -1)
	    val = -1;
	for (; lox <= hix; lox++)
	    func[lox] = val;
	func[sampleCount] = func[0];
	cv.repaint();
    }

    void editPhase(int x, int y) {
	if (selectedCoef == -1)
	    return;
	int panelHeight = getPanelHeight();
	double ymult = .75 * panelHeight/2;
	double midy = ((panelHeight * 5) / 2);
	double coef = -(y-midy) *pi / ymult;
	if (coef < -pi)
	    coef = -pi;
	if (coef > pi)
	    coef = pi;
	if (phasecoef[selectedCoef] == coef)
	    return;
	phasecoef[selectedCoef] = coef;
	cv.repaint();
    }

    public void componentHidden(ComponentEvent e){}
    public void componentMoved(ComponentEvent e){}
    public void componentShown(ComponentEvent e) {
	cv.repaint();
    }

    public void componentResized(ComponentEvent e) {
	handleResize();
	cv.repaint(100);
    }
    public void actionPerformed(ActionEvent e) {
	if (e.getSource() == triangleButton) {
	    doTriangle();
	    cv.repaint();
	}
	if (e.getSource() == sineButton) {
	    doSine();
	    cv.repaint();
	}
	if (e.getSource() == rectButton) {
	    doRect();
	    cv.repaint();
	}
	if (e.getSource() == fullRectButton) {
	    doFullRect();
	    cv.repaint();
	}
	if (e.getSource() == squareButton) {
	    doSquare();
	    cv.repaint();
	}
	if (e.getSource() == noiseButton) {
	    doNoise();
	    cv.repaint();
	}
	if (e.getSource() == blankButton) {
	    doBlank();
	    cv.repaint();
	}
	if (e.getSource() == sawtoothButton) {
	    doSawtooth();
	    cv.repaint();
	}
	if (e.getSource() == clipButton) {
	    doClip();
	    cv.repaint();
	}
	if (e.getSource() == quantizeButton) {
	    doQuantize();
	    cv.repaint();
	}
	if (e.getSource() == resampleButton) {
	    doResample();
	    cv.repaint();
	}
	if (e.getSource() == playButton) {
	    doPlay();
	}
    }
    public void adjustmentValueChanged(AdjustmentEvent e) {
	if (e.getSource() == termBar) {
	    cv.repaint();
	}
    }
    public void mouseDragged(MouseEvent e) {
	dragging = true;
	edit(e);
    }
    public void mouseMoved(MouseEvent e) {
	if ((e.getModifiers() & MouseEvent.BUTTON1_MASK) != 0)
	    return;
	int x = e.getX();
	int y = e.getY();
	dragX = x; dragY = y;
	int panelHeight = getPanelHeight();
	int oldCoef = selectedCoef;
	selectedCoef = -1;
	selection = 0;
	if (y < panelHeight)
	    selection = SEL_FUNC;
	if (y >= panelHeight && y < panelHeight*3) {
	    int termWidth = getTermWidth();
	    selectedCoef = x/termWidth;
	    if (selectedCoef > termBar.getValue())
		selectedCoef = -1;
	    if (selectedCoef != -1)
		selection = (y >= panelHeight * 2) ? SEL_PHASE : SEL_MAG;
	}
	if (selectedCoef != oldCoef)
	    cv.repaint();
    }
    public void mouseClicked(MouseEvent e) {
    }
    public void mouseEntered(MouseEvent e) {
    }
    public void mouseExited(MouseEvent e) {
    }
    public void mousePressed(MouseEvent e) {
	if ((e.getModifiers() & MouseEvent.BUTTON3_MASK) != 0 &&
	    selectedCoef != -1) {
	    termBar.setValue(selectedCoef+1);
	    cv.repaint();
	}
	if ((e.getModifiers() & MouseEvent.BUTTON1_MASK) == 0)
	    return;
	dragging = true;
	edit(e);
    }
    public void mouseReleased(MouseEvent e) {
	if ((e.getModifiers() & MouseEvent.BUTTON1_MASK) == 0)
	    return;
	dragging = false;
	if (selection == SEL_FUNC)
	    transform();
	else if (selection != SEL_NONE)
	    doSetFunc();
	cv.repaint();
    }
    public boolean handleEvent(Event ev) {
        if (ev.id == Event.WINDOW_DESTROY) {
            applet.destroyFrame();
            return true;
        }
        return super.handleEvent(ev);
    }
}


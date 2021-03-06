
Imports System.Math

Public Class zCalc
    Inherits System.Windows.Forms.Form

#Region " Designer Member Variables... "

    Friend WithEvents mMain As System.Windows.Forms.MainMenu
    Friend WithEvents tDisp As System.Windows.Forms.TextBox
    Friend WithEvents lDisp As System.Windows.Forms.Label
    Friend WithEvents b7 As System.Windows.Forms.Button
    Friend WithEvents b8 As System.Windows.Forms.Button
    Friend WithEvents b9 As System.Windows.Forms.Button
    Friend WithEvents b4 As System.Windows.Forms.Button
    Friend WithEvents b5 As System.Windows.Forms.Button
    Friend WithEvents b6 As System.Windows.Forms.Button
    Friend WithEvents b1 As System.Windows.Forms.Button
    Friend WithEvents b2 As System.Windows.Forms.Button
    Friend WithEvents b3 As System.Windows.Forms.Button
    Friend WithEvents b0 As System.Windows.Forms.Button
    Friend WithEvents bMul As System.Windows.Forms.Button
    Friend WithEvents bDP As System.Windows.Forms.Button
    Friend WithEvents bSqrt As System.Windows.Forms.Button
    Friend WithEvents bPlus As System.Windows.Forms.Button
    Friend WithEvents bDMS As System.Windows.Forms.Button
    Friend WithEvents bPower As System.Windows.Forms.Button
    Friend WithEvents bCLS As System.Windows.Forms.Button
    Friend WithEvents bDiv As System.Windows.Forms.Button
    Friend WithEvents bFact As System.Windows.Forms.Button
    Friend WithEvents bMin As System.Windows.Forms.Button
    Friend WithEvents bMod As System.Windows.Forms.Button
    Friend WithEvents bEXE As System.Windows.Forms.Button
    Friend WithEvents bExp As System.Windows.Forms.Button
    Friend WithEvents bBS As System.Windows.Forms.Button
    Friend WithEvents bRight As System.Windows.Forms.Button
    Friend WithEvents bLeft As System.Windows.Forms.Button
    Friend WithEvents bClose As System.Windows.Forms.Button
    Friend WithEvents bOpen As System.Windows.Forms.Button
    Friend WithEvents cSHIFT As System.Windows.Forms.CheckBox
    Friend WithEvents cMem As System.Windows.Forms.CheckBox
    Friend WithEvents cInv As System.Windows.Forms.CheckBox
    Friend WithEvents cHyp As System.Windows.Forms.CheckBox
    Friend WithEvents cGroup As System.Windows.Forms.CheckBox
    Friend WithEvents cDMS As System.Windows.Forms.CheckBox
    Friend WithEvents mAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mExit As System.Windows.Forms.MenuItem
    Friend WithEvents rDeg As System.Windows.Forms.RadioButton
    Friend WithEvents rRad As System.Windows.Forms.RadioButton
    Friend WithEvents rGra As System.Windows.Forms.RadioButton
    Friend WithEvents pDegRadGra As System.Windows.Forms.Panel
    Friend WithEvents pShfInvHyp As System.Windows.Forms.Panel
    Friend WithEvents pMemGrpDms As System.Windows.Forms.Panel
    Friend WithEvents bDel As System.Windows.Forms.Button
    Friend WithEvents mConstants As System.Windows.Forms.MenuItem
    Friend WithEvents mSpeedOfLight As System.Windows.Forms.MenuItem
    Friend WithEvents mPlanck As System.Windows.Forms.MenuItem
    Friend WithEvents mGravitational As System.Windows.Forms.MenuItem
    Friend WithEvents mElementaryCharge As System.Windows.Forms.MenuItem
    Friend WithEvents mElectronRestMass As System.Windows.Forms.MenuItem
    Friend WithEvents mAtomicMass As System.Windows.Forms.MenuItem
    Friend WithEvents mAvogadro As System.Windows.Forms.MenuItem
    Friend WithEvents mBoltzmann As System.Windows.Forms.MenuItem
    Friend WithEvents mMolarVolume As System.Windows.Forms.MenuItem
    Friend WithEvents mAccelerationOfFreeFall As System.Windows.Forms.MenuItem
    Friend WithEvents mMolarGas As System.Windows.Forms.MenuItem
    Friend WithEvents mPermittivity As System.Windows.Forms.MenuItem
    Friend WithEvents mPermeability As System.Windows.Forms.MenuItem

#End Region

#Region " Other Member Variables... "

    Private Enum charClasify
        digit
        decPoint
        digitDec
        exponent
        expSign
        digitExp
        degree
        digitMin
        minute
        digitSec
        second
        begin
        signOp
        operator
        funct
        sqrt
        fact
        sign
        leftBracket
        rightBracket
    End Enum

    Private Enum tokenArg
        rightBracket
        digit
        variable
        opPlusMinus
        opMod
        opMulDiv
        opPower
        opD2ID
        funcSqrt
        funcFact
        mathFunction
        sign
        leftBracket
    End Enum

    Private Enum selectDMS
        degree
        minute
        second
    End Enum

    Private mem(9) As Double
    Private tokens() As String
    Private opStack() As String
    Private numStack() As Double
    Private tokensCtr As Integer
    Private opStackCtr As Integer
    Private numStackCtr As Integer
    Private result As Double
    Private isModeEdit As Boolean
    Private decPointChar As String = Mid(CStr(System.Math.PI), 2, 1)
    Private degreeChar As String = "°"
    Private minuteChar As String = "’"
    Private secondChar As String = Chr(148)
    Private sqrtChar As String = "√"
    Private piChar As String = "π"
    Private multiplyChar As String = "×"
    Private additionOperatorChar As String = "0+"
    Private substractionOperatorChar As String = "0-"
    Private plusSignChar As String = "+"
    Private minusSignChar As String = "-"
    Private leftPointingChar = "<—"
    Private rightPointingChar = "—>"
    Private curDMS As selectDMS
    Private prgDesc As String
    Private prgVer As String
    Private myName As String
    Private prgCright As String
    Private herName As String
    Private myCode1 As String
    Private myCode2 As String
    Private herCode1 As String
    Private herCode2 As String

#End Region

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim rsrc As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(zCalc))
        Dim ctrl As System.Windows.Forms.Control
        Dim btn As System.Windows.Forms.Button

        Me.Text = CType(rsrc.GetObject("$this.Name"), String)

        Me.BackColor = Color.AliceBlue
        Me.tDisp.BackColor = Color.Aquamarine
        Me.lDisp.BackColor = Me.tDisp.BackColor

        Me.pShfInvHyp.BackColor = Me.BackColor
        Me.pMemGrpDms.BackColor = Me.pShfInvHyp.BackColor
        Me.pDegRadGra.BackColor = Me.pShfInvHyp.BackColor

        For Each ctrl In Me.Controls
            If TypeName(ctrl) = "Button" Then
                btn = ctrl
                btn.BackColor = Color.DarkBlue
                btn.ForeColor = Color.White
                btn.Font = New Font(btn.Font.Name, 9.75!, FontStyle.Regular)
            End If
        Next

        Me.bEXE.Text = "EXE"
        Me.bEXE.Font = New Font(Me.bEXE.Font.Name, Me.bEXE.Font.Size, FontStyle.Bold)

        Me.setButtonText()

        Me.rDeg.Checked = True

        Me.isModeEdit = True
        Me.lDisp.Text = ""
        Me.setModeDisp()
        tDisp.Focus()

        initAbout()
    End Sub

#Region " Windows Form Designer generated code "

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(zCalc))
        Me.mMain = New System.Windows.Forms.MainMenu
        Me.mConstants = New System.Windows.Forms.MenuItem
        Me.mSpeedOfLight = New System.Windows.Forms.MenuItem
        Me.mPlanck = New System.Windows.Forms.MenuItem
        Me.mGravitational = New System.Windows.Forms.MenuItem
        Me.mElementaryCharge = New System.Windows.Forms.MenuItem
        Me.mElectronRestMass = New System.Windows.Forms.MenuItem
        Me.mAtomicMass = New System.Windows.Forms.MenuItem
        Me.mAvogadro = New System.Windows.Forms.MenuItem
        Me.mBoltzmann = New System.Windows.Forms.MenuItem
        Me.mMolarVolume = New System.Windows.Forms.MenuItem
        Me.mAccelerationOfFreeFall = New System.Windows.Forms.MenuItem
        Me.mMolarGas = New System.Windows.Forms.MenuItem
        Me.mPermittivity = New System.Windows.Forms.MenuItem
        Me.mPermeability = New System.Windows.Forms.MenuItem
        Me.mAbout = New System.Windows.Forms.MenuItem
        Me.mExit = New System.Windows.Forms.MenuItem
        Me.tDisp = New System.Windows.Forms.TextBox
        Me.lDisp = New System.Windows.Forms.Label
        Me.b7 = New System.Windows.Forms.Button
        Me.b8 = New System.Windows.Forms.Button
        Me.b9 = New System.Windows.Forms.Button
        Me.b4 = New System.Windows.Forms.Button
        Me.b5 = New System.Windows.Forms.Button
        Me.b6 = New System.Windows.Forms.Button
        Me.b1 = New System.Windows.Forms.Button
        Me.b2 = New System.Windows.Forms.Button
        Me.b3 = New System.Windows.Forms.Button
        Me.b0 = New System.Windows.Forms.Button
        Me.bDP = New System.Windows.Forms.Button
        Me.bSqrt = New System.Windows.Forms.Button
        Me.bMul = New System.Windows.Forms.Button
        Me.bPlus = New System.Windows.Forms.Button
        Me.bDMS = New System.Windows.Forms.Button
        Me.bPower = New System.Windows.Forms.Button
        Me.bCLS = New System.Windows.Forms.Button
        Me.bDiv = New System.Windows.Forms.Button
        Me.bFact = New System.Windows.Forms.Button
        Me.bMin = New System.Windows.Forms.Button
        Me.bMod = New System.Windows.Forms.Button
        Me.bEXE = New System.Windows.Forms.Button
        Me.bExp = New System.Windows.Forms.Button
        Me.bBS = New System.Windows.Forms.Button
        Me.bDel = New System.Windows.Forms.Button
        Me.bRight = New System.Windows.Forms.Button
        Me.bLeft = New System.Windows.Forms.Button
        Me.bClose = New System.Windows.Forms.Button
        Me.bOpen = New System.Windows.Forms.Button
        Me.cSHIFT = New System.Windows.Forms.CheckBox
        Me.cMem = New System.Windows.Forms.CheckBox
        Me.cInv = New System.Windows.Forms.CheckBox
        Me.cHyp = New System.Windows.Forms.CheckBox
        Me.cGroup = New System.Windows.Forms.CheckBox
        Me.cDMS = New System.Windows.Forms.CheckBox
        Me.pDegRadGra = New System.Windows.Forms.Panel
        Me.rDeg = New System.Windows.Forms.RadioButton
        Me.rRad = New System.Windows.Forms.RadioButton
        Me.rGra = New System.Windows.Forms.RadioButton
        Me.pShfInvHyp = New System.Windows.Forms.Panel
        Me.pMemGrpDms = New System.Windows.Forms.Panel
        '
        'mMain
        '
        Me.mMain.MenuItems.Add(Me.mConstants)
        Me.mMain.MenuItems.Add(Me.mAbout)
        Me.mMain.MenuItems.Add(Me.mExit)
        '
        'mConstants
        '
        Me.mConstants.MenuItems.Add(Me.mSpeedOfLight)
        Me.mConstants.MenuItems.Add(Me.mPlanck)
        Me.mConstants.MenuItems.Add(Me.mGravitational)
        Me.mConstants.MenuItems.Add(Me.mElementaryCharge)
        Me.mConstants.MenuItems.Add(Me.mElectronRestMass)
        Me.mConstants.MenuItems.Add(Me.mAtomicMass)
        Me.mConstants.MenuItems.Add(Me.mAvogadro)
        Me.mConstants.MenuItems.Add(Me.mBoltzmann)
        Me.mConstants.MenuItems.Add(Me.mMolarVolume)
        Me.mConstants.MenuItems.Add(Me.mAccelerationOfFreeFall)
        Me.mConstants.MenuItems.Add(Me.mMolarGas)
        Me.mConstants.MenuItems.Add(Me.mPermittivity)
        Me.mConstants.MenuItems.Add(Me.mPermeability)
        Me.mConstants.Text = "Constants"
        '
        'mSpeedOfLight
        '
        Me.mSpeedOfLight.Text = "Speed of light in vacuum"
        '
        'mPlanck
        '
        Me.mPlanck.Text = "Planck's constant"
        '
        'mGravitational
        '
        Me.mGravitational.Text = "Gravitational constant"
        '
        'mElementaryCharge
        '
        Me.mElementaryCharge.Text = "Elementary charge"
        '
        'mElectronRestMass
        '
        Me.mElectronRestMass.Text = "Electron rest mass"
        '
        'mAtomicMass
        '
        Me.mAtomicMass.Text = "Atomic mass unit"
        '
        'mAvogadro
        '
        Me.mAvogadro.Text = "Avogadro constant"
        '
        'mBoltzmann
        '
        Me.mBoltzmann.Text = "Boltzmann constant"
        '
        'mMolarVolume
        '
        Me.mMolarVolume.Text = "Molar volume of idel gas at s.t.p."
        '
        'mAccelerationOfFreeFall
        '
        Me.mAccelerationOfFreeFall.Text = "Acceleration of free fall"
        '
        'mMolarGas
        '
        Me.mMolarGas.Text = "Molar gas constant"
        '
        'mPermittivity
        '
        Me.mPermittivity.Text = "Permittivity of vacuum"
        '
        'mPermeability
        '
        Me.mPermeability.Text = "Permeability of vacuum"
        '
        'mAbout
        '
        Me.mAbout.Text = "About"
        '
        'mExit
        '
        Me.mExit.Text = "Exit"
        '
        'tDisp
        '
        Me.tDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular)
        Me.tDisp.Location = New System.Drawing.Point(8, 8)
        Me.tDisp.Size = New System.Drawing.Size(220, 26)
        Me.tDisp.Text = ""
        Me.tDisp.WordWrap = False
        '
        'lDisp
        '
        Me.lDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular)
        Me.lDisp.Location = New System.Drawing.Point(9, 11)
        Me.lDisp.Size = New System.Drawing.Size(218, 22)
        Me.lDisp.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'b7
        '
        Me.b7.Location = New System.Drawing.Point(2, 139)
        Me.b7.Size = New System.Drawing.Size(36, 28)
        '
        'b8
        '
        Me.b8.Location = New System.Drawing.Point(42, 139)
        Me.b8.Size = New System.Drawing.Size(36, 28)
        '
        'b9
        '
        Me.b9.Location = New System.Drawing.Point(82, 139)
        Me.b9.Size = New System.Drawing.Size(36, 28)
        '
        'b4
        '
        Me.b4.Location = New System.Drawing.Point(2, 169)
        Me.b4.Size = New System.Drawing.Size(36, 28)
        '
        'b5
        '
        Me.b5.Location = New System.Drawing.Point(42, 169)
        Me.b5.Size = New System.Drawing.Size(36, 28)
        '
        'b6
        '
        Me.b6.Location = New System.Drawing.Point(82, 169)
        Me.b6.Size = New System.Drawing.Size(36, 28)
        '
        'b1
        '
        Me.b1.Location = New System.Drawing.Point(2, 199)
        Me.b1.Size = New System.Drawing.Size(36, 28)
        '
        'b2
        '
        Me.b2.Location = New System.Drawing.Point(42, 199)
        Me.b2.Size = New System.Drawing.Size(36, 28)
        '
        'b3
        '
        Me.b3.Location = New System.Drawing.Point(82, 199)
        Me.b3.Size = New System.Drawing.Size(36, 28)
        '
        'b0
        '
        Me.b0.Location = New System.Drawing.Point(2, 229)
        Me.b0.Size = New System.Drawing.Size(36, 28)
        '
        'bDP
        '
        Me.bDP.Location = New System.Drawing.Point(42, 229)
        Me.bDP.Size = New System.Drawing.Size(36, 28)
        '
        'bSqrt
        '
        Me.bSqrt.Location = New System.Drawing.Point(122, 139)
        Me.bSqrt.Size = New System.Drawing.Size(36, 28)
        '
        'bMul
        '
        Me.bMul.Location = New System.Drawing.Point(122, 169)
        Me.bMul.Size = New System.Drawing.Size(36, 28)
        '
        'bPlus
        '
        Me.bPlus.Location = New System.Drawing.Point(122, 199)
        Me.bPlus.Size = New System.Drawing.Size(36, 28)
        '
        'bDMS
        '
        Me.bDMS.Location = New System.Drawing.Point(122, 229)
        Me.bDMS.Size = New System.Drawing.Size(36, 28)
        '
        'bPower
        '
        Me.bPower.Location = New System.Drawing.Point(162, 139)
        Me.bPower.Size = New System.Drawing.Size(36, 28)
        '
        'bCLS
        '
        Me.bCLS.Location = New System.Drawing.Point(202, 139)
        Me.bCLS.Size = New System.Drawing.Size(36, 28)
        '
        'bDiv
        '
        Me.bDiv.Location = New System.Drawing.Point(162, 169)
        Me.bDiv.Size = New System.Drawing.Size(36, 28)
        '
        'bFact
        '
        Me.bFact.Location = New System.Drawing.Point(202, 169)
        Me.bFact.Size = New System.Drawing.Size(36, 28)
        '
        'bMin
        '
        Me.bMin.Location = New System.Drawing.Point(162, 199)
        Me.bMin.Size = New System.Drawing.Size(36, 28)
        '
        'bMod
        '
        Me.bMod.Location = New System.Drawing.Point(202, 199)
        Me.bMod.Size = New System.Drawing.Size(36, 28)
        '
        'bEXE
        '
        Me.bEXE.Location = New System.Drawing.Point(162, 229)
        Me.bEXE.Size = New System.Drawing.Size(76, 28)
        '
        'bExp
        '
        Me.bExp.Location = New System.Drawing.Point(82, 229)
        Me.bExp.Size = New System.Drawing.Size(36, 28)
        '
        'bBS
        '
        Me.bBS.Location = New System.Drawing.Point(202, 109)
        Me.bBS.Size = New System.Drawing.Size(36, 28)
        '
        'bDel
        '
        Me.bDel.Location = New System.Drawing.Point(162, 109)
        Me.bDel.Size = New System.Drawing.Size(36, 28)
        '
        'bRight
        '
        Me.bRight.Location = New System.Drawing.Point(122, 109)
        Me.bRight.Size = New System.Drawing.Size(36, 28)
        '
        'bLeft
        '
        Me.bLeft.Location = New System.Drawing.Point(82, 109)
        Me.bLeft.Size = New System.Drawing.Size(36, 28)
        '
        'bClose
        '
        Me.bClose.Location = New System.Drawing.Point(42, 109)
        Me.bClose.Size = New System.Drawing.Size(36, 28)
        '
        'bOpen
        '
        Me.bOpen.Location = New System.Drawing.Point(2, 109)
        Me.bOpen.Size = New System.Drawing.Size(36, 28)
        '
        'cSHIFT
        '
        Me.cSHIFT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.cSHIFT.Size = New System.Drawing.Size(64, 20)
        Me.cSHIFT.Text = "SHIFT"
        '
        'cMem
        '
        Me.cMem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.cMem.Size = New System.Drawing.Size(64, 20)
        Me.cMem.Text = "Mem"
        '
        'cInv
        '
        Me.cInv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.cInv.Location = New System.Drawing.Point(0, 20)
        Me.cInv.Size = New System.Drawing.Size(64, 20)
        Me.cInv.Text = "inv"
        '
        'cHyp
        '
        Me.cHyp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.cHyp.Location = New System.Drawing.Point(0, 40)
        Me.cHyp.Size = New System.Drawing.Size(64, 20)
        Me.cHyp.Text = "hyp"
        '
        'cGroup
        '
        Me.cGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.cGroup.Location = New System.Drawing.Point(0, 20)
        Me.cGroup.Size = New System.Drawing.Size(64, 20)
        Me.cGroup.Text = "Group"
        '
        'cDMS
        '
        Me.cDMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.cDMS.Location = New System.Drawing.Point(0, 40)
        Me.cDMS.Size = New System.Drawing.Size(64, 20)
        Me.cDMS.Text = "DMS"
        '
        'pDegRadGra
        '
        Me.pDegRadGra.Controls.Add(Me.rDeg)
        Me.pDegRadGra.Controls.Add(Me.rRad)
        Me.pDegRadGra.Controls.Add(Me.rGra)
        Me.pDegRadGra.Location = New System.Drawing.Point(161, 41)
        Me.pDegRadGra.Size = New System.Drawing.Size(64, 60)
        '
        'rDeg
        '
        Me.rDeg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.rDeg.Size = New System.Drawing.Size(64, 20)
        Me.rDeg.Text = "Deg"
        '
        'rRad
        '
        Me.rRad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.rRad.Location = New System.Drawing.Point(0, 20)
        Me.rRad.Size = New System.Drawing.Size(64, 20)
        Me.rRad.Text = "Rad"
        '
        'rGra
        '
        Me.rGra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular)
        Me.rGra.Location = New System.Drawing.Point(0, 40)
        Me.rGra.Size = New System.Drawing.Size(64, 20)
        Me.rGra.Text = "Gra"
        '
        'pShfInvHyp
        '
        Me.pShfInvHyp.Controls.Add(Me.cSHIFT)
        Me.pShfInvHyp.Controls.Add(Me.cInv)
        Me.pShfInvHyp.Controls.Add(Me.cHyp)
        Me.pShfInvHyp.Location = New System.Drawing.Point(8, 40)
        Me.pShfInvHyp.Size = New System.Drawing.Size(64, 60)
        '
        'pMemGrpDms
        '
        Me.pMemGrpDms.Controls.Add(Me.cMem)
        Me.pMemGrpDms.Controls.Add(Me.cGroup)
        Me.pMemGrpDms.Controls.Add(Me.cDMS)
        Me.pMemGrpDms.Location = New System.Drawing.Point(80, 40)
        Me.pMemGrpDms.Size = New System.Drawing.Size(64, 60)
        '
        'zCalc
        '
        Me.ClientSize = New System.Drawing.Size(242, 265)
        Me.Controls.Add(Me.pMemGrpDms)
        Me.Controls.Add(Me.pShfInvHyp)
        Me.Controls.Add(Me.pDegRadGra)
        Me.Controls.Add(Me.bBS)
        Me.Controls.Add(Me.bDel)
        Me.Controls.Add(Me.bRight)
        Me.Controls.Add(Me.bLeft)
        Me.Controls.Add(Me.bClose)
        Me.Controls.Add(Me.bOpen)
        Me.Controls.Add(Me.bExp)
        Me.Controls.Add(Me.bEXE)
        Me.Controls.Add(Me.bMod)
        Me.Controls.Add(Me.bMin)
        Me.Controls.Add(Me.bFact)
        Me.Controls.Add(Me.bDiv)
        Me.Controls.Add(Me.bCLS)
        Me.Controls.Add(Me.bPower)
        Me.Controls.Add(Me.bDMS)
        Me.Controls.Add(Me.bPlus)
        Me.Controls.Add(Me.bMul)
        Me.Controls.Add(Me.bSqrt)
        Me.Controls.Add(Me.bDP)
        Me.Controls.Add(Me.b0)
        Me.Controls.Add(Me.b3)
        Me.Controls.Add(Me.b2)
        Me.Controls.Add(Me.b1)
        Me.Controls.Add(Me.b6)
        Me.Controls.Add(Me.b5)
        Me.Controls.Add(Me.b4)
        Me.Controls.Add(Me.b9)
        Me.Controls.Add(Me.b8)
        Me.Controls.Add(Me.b7)
        Me.Controls.Add(Me.lDisp)
        Me.Controls.Add(Me.tDisp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mMain

    End Sub

#End Region

#Region " zCalc Events... "

    Private Sub zCalculator_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim x As Integer, y As Integer, t As Integer

        If Height > Width Then
            ' Portrait
            Me.ClientSize = New Size(240, 268)
            x = 3
            y = 4
            tDisp.Width = b5.Width * 6 + x * 5
            tDisp.Location = New Point((Me.ClientSize.Width - tDisp.Width) / 2 - 1, 7)
            pShfInvHyp.Location = New Point(12, tDisp.Bottom + 6)
            pMemGrpDms.Location = New Point(pShfInvHyp.Right + pShfInvHyp.Left, pShfInvHyp.Top)
            pDegRadGra.Location = New Point(pMemGrpDms.Right + pShfInvHyp.Left, pShfInvHyp.Top)
            bOpen.Location = New Point(tDisp.Left, pDegRadGra.Bottom + 6)
        Else
            ' Landscape
            Me.ClientSize = New Size(320, 188)
            x = 5
            y = 2
            tDisp.Width = b5.Width * 6 + x * 5
            tDisp.Location = New Point(6, 5)
            pDegRadGra.Location = New Point(tDisp.Right + 6, 4)
            pShfInvHyp.Location = New Point(pDegRadGra.Left, pDegRadGra.Bottom)
            pMemGrpDms.Location = New Point(pDegRadGra.Left, pShfInvHyp.Bottom)
            bOpen.Location = New Point(tDisp.Left, tDisp.Bottom + 4)
        End If

        lDisp.Width = tDisp.Width - 4
        lDisp.Location = New Point(tDisp.Left + 2, tDisp.Top + 3)

        bEXE.Width = b5.Width * 2 + x

        bClose.Location = New Point(bOpen.Right + x, bOpen.Top)
        bLeft.Location = New Point(bClose.Right + x, bOpen.Top)
        bRight.Location = New Point(bLeft.Right + x, bOpen.Top)
        bDel.Location = New Point(bRight.Right + x, bOpen.Top)
        bBS.Location = New Point(bDel.Right + x, bOpen.Top)

        b7.Location = New Point(bOpen.Left, bOpen.Bottom + y)
        b8.Location = New Point(bClose.Left, b7.Top)
        b9.Location = New Point(bLeft.Left, b7.Top)
        bSqrt.Location = New Point(bRight.Left, b7.Top)
        bPower.Location = New Point(bDel.Left, b7.Top)
        bCLS.Location = New Point(bBS.Left, b7.Top)

        b4.Location = New Point(bOpen.Left, b7.Bottom + y)
        b5.Location = New Point(bClose.Left, b4.Top)
        b6.Location = New Point(bLeft.Left, b4.Top)
        bMul.Location = New Point(bRight.Left, b4.Top)
        bDiv.Location = New Point(bDel.Left, b4.Top)
        bFact.Location = New Point(bBS.Left, b4.Top)

        b1.Location = New Point(bOpen.Left, b4.Bottom + y)
        b2.Location = New Point(bClose.Left, b1.Top)
        b3.Location = New Point(bLeft.Left, b1.Top)
        bPlus.Location = New Point(bRight.Left, b1.Top)
        bMin.Location = New Point(bDel.Left, b1.Top)
        bMod.Location = New Point(bBS.Left, b1.Top)

        b0.Location = New Point(bOpen.Left, b1.Bottom + y)
        bDP.Location = New Point(bClose.Left, b0.Top)
        bExp.Location = New Point(bLeft.Left, b0.Top)
        bDMS.Location = New Point(bRight.Left, b0.Top)
        bEXE.Location = New Point(bDel.Left, b0.Top)
    End Sub

    Private Sub zCalc_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        tDisp.Focus()
    End Sub

    Private Sub mAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAbout.Click
        Dim s As String

        ' Scientific Calculator
        ' Version 1.0
        '
        ' Created by:
        ' Iskandar Z. Nasibu,
        ' Gorontalo,
        ' April 2007.

        s = prgDesc & vbCrLf & _
            prgVer & vbCrLf & _
                vbCrLf & _
            Chr(Keys.C) & Chr(Keys.R + 32) & Chr(Keys.E + 32) & Chr(Keys.A + 32) & Chr(Keys.T + 32) & _
                Chr(Keys.E + 32) & Chr(Keys.D + 32) & Chr(Keys.Space) & Chr(Keys.B + 32) & Chr(Keys.Y + 32) & _
                Chr(58) & vbCrLf & _
            myName & vbCrLf & _
            prgCright

        MsgBox(s)

        tDisp.Focus()
    End Sub

    Private Sub mExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mExit.Click
        Close()
    End Sub

    Private Sub cSHIFT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cSHIFT.Click
        setButtonText()
        tDisp.Focus()
    End Sub

    Private Sub cMem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cMem.Click
        cSHIFT.Enabled = Not cMem.Checked
        tDisp.Focus()
    End Sub

    Private Sub cGroupDMS_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cGroup.Click, cDMS.Click
        If CType(sender, CheckBox) Is cDMS Then
            cGroup.Enabled = Not cDMS.Checked
        End If

        If Not isModeEdit Then
            lDisp.Text = ""
            setModeDisp()
        End If
        tDisp.Focus()
    End Sub

    Private Sub options_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cInv.Click, cHyp.Click, rDeg.Click, rRad.Click, rGra.Click
        tDisp.Focus()
    End Sub

    Private Sub tDisp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
     Handles tDisp.KeyDown
        If e.KeyCode = Keys.Q And e.KeyData - Keys.Control = e.KeyCode Then
            Close()
        End If

        Select Case e.KeyCode
            Case Keys.Left, Keys.Up, Keys.Right, Keys.Down, Keys.Delete, Keys.Home, Keys.End
                If Not isModeEdit Then
                    setModeEdit()
                    e.Handled = True
                Else
                    Select Case e.KeyCode
                        Case Keys.Left, Keys.Up
                            If tDisp.SelectionStart = 0 Then
                                tDisp.SelectionStart = tDisp.Text.Length
                                e.Handled = True
                            End If

                        Case Keys.Right, Keys.Down
                            If tDisp.SelectionStart = tDisp.Text.Length Then
                                tDisp.SelectionStart = 0
                                e.Handled = True
                            End If
                    End Select
                End If
        End Select
    End Sub

    Private Sub tDisp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles tDisp.KeyPress
        Dim c As String = CStr(e.KeyChar)

        e.Handled = True

        Select Case c
            Case "=", Chr(Keys.Enter)
                button_Click(bEXE, e)
                Exit Sub

            Case decPointChar
                If cSHIFT.Checked Then
                    cSHIFT.Checked = False
                    setButtonText()
                End If

                button_Click(bDP, e)
                Exit Sub

            Case Chr(Keys.Escape)
                tDisp.Text = ""

                If Not isModeEdit Then
                    setModeEdit()
                End If

                Exit Sub

            Case Chr(Keys.Back)
                If Not isModeEdit Then
                    setModeEdit()
                Else
                    e.Handled = False
                End If

                Exit Sub

            Case "A" To "Z"
                c = c.ToLower

            Case "*"
                c = multiplyChar

            Case "\"
                c = sqrtChar

            Case "0" To "9", "a" To "z", "(", ")", "!", "^", "/", _
            decPointChar, sqrtChar, multiplyChar, plusSignChar, minusSignChar

            Case Else
                Beep()
                Exit Sub
        End Select

        If Not isModeEdit Then
            setModeEdit()

            If result <> 0 Then
                Select Case c
                    Case "!", "^", multiplyChar, "/", plusSignChar, minusSignChar
                        c = CStr(result) & c
                    Case sqrtChar
                        c &= CStr(result)
                End Select
            End If

            tDisp.Text = ""
        End If


        insertText(c)
    End Sub

    Private Sub mConstantsItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mSpeedOfLight.Click, mPlanck.Click, mGravitational.Click, mElementaryCharge.Click, _
    mElectronRestMass.Click, mAtomicMass.Click, mAvogadro.Click, mBoltzmann.Click, mMolarVolume.Click, _
    mAccelerationOfFreeFall.Click, mMolarGas.Click, mPermittivity.Click, mPermeability.Click
        Dim c As String

        If Not isModeEdit Then
            tDisp.Text = ""
            setModeEdit()
        End If

        Select Case Microsoft.VisualBasic.Left(CType(sender, MenuItem).Text, 7)
            Case "Speed o"
                c = CStr(299792458.0#)

            Case "Planck'"
                c = CStr(6.626176E-34#)

            Case "Gravita"
                c = CStr(0.00000000006672#)

            Case "Element"
                c = CStr(1.6021892E-19#)

            Case "Electro"
                c = CStr(9.109534E-31#)

            Case "Atomic "
                c = CStr(1.6605655E-27#)

            Case "Avogadr"
                c = CStr(6.022045E+23#)

            Case "Boltzma"
                c = CStr(1.380662E-23#)

            Case "Molar v"
                c = CStr(0.02241383#)

            Case "Acceler"
                c = CStr(9.80665#)

            Case "Molar g"
                c = CStr(8.31441#)

            Case "Permitt"
                c = CStr(0.000000000008854187818#)

            Case "Permeab"
                c = CStr(0.000001256637061#)
        End Select

        insertText(c)
    End Sub

    Private Sub button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles b0.Click, b1.Click, b2.Click, b3.Click, b4.Click, b5.Click, b6.Click, b7.Click, b8.Click, b9.Click, _
    bDP.Click, bExp.Click, bDMS.Click, bOpen.Click, bClose.Click, _
    bSqrt.Click, bPower.Click, bMul.Click, bDiv.Click, bFact.Click, bPlus.Click, bMin.Click, bMod.Click, _
    bBS.Click, bDel.Click, bLeft.Click, bRight.Click, bCLS.Click, bEXE.Click
        Dim txt As String

        txt = CType(sender, Button).Text
        tDisp.Focus()

        If cMem.Checked Then
            Select Case txt
                Case "0" To "9"
                    cMem.Checked = False
                    cSHIFT.Enabled = True

                    If isModeEdit Then
                        insertText("m" & txt)
                    Else
                        mem(Asc(txt) - 48) = result
                    End If

                Case Else
                    Beep()
            End Select

            Exit Sub
        End If

        If txt = "EXE" Then
            If isModeEdit Then
                If tDisp.Text = "" Then
                    result = 0
                    lDisp.Text = ""
                Else
                    If parseExpression() Then
                        If checkTokens() Then
                            getResult()
                        End If
                    End If
                End If
                setModeDisp()
            Else
                Beep()
            End If
            GoTo returnSHIFTstate
        End If

        If txt = "CLS" Then
            If tDisp.Text <> "" Then
                tDisp.Text = ""
            End If

            If Not isModeEdit Then
                setModeEdit()
            End If

            Exit Sub
        End If

        Dim pos As Integer = tDisp.SelectionStart
        Dim l As Integer = tDisp.SelectionLength

        If txt = degreeChar & " " & minuteChar & " " & secondChar Then
            If isModeEdit Then
                If pos > 0 Then
                    txt = Mid(tDisp.Text, pos, 1)
                    Select Case txt
                        Case degreeChar, minuteChar, secondChar
                            Select Case txt
                                Case degreeChar
                                    txt = minuteChar
                                    curDMS = selectDMS.minute

                                Case minuteChar
                                    txt = secondChar
                                    curDMS = selectDMS.second

                                Case secondChar
                                    txt = degreeChar
                                    curDMS = selectDMS.degree
                            End Select

                            tDisp.SelectionStart = pos - 1
                            tDisp.SelectionLength = l + 1

                        Case "0" To "9"
                            Select Case curDMS
                                Case selectDMS.degree
                                    txt = degreeChar

                                Case selectDMS.minute
                                    txt = minuteChar

                                Case selectDMS.second
                                    txt = secondChar
                            End Select

                        Case Else
                            Beep()
                            Exit Sub
                    End Select

                    curDMS = (curDMS + 1) Mod 3
                    insertText(txt)
                Else
                    Beep()
                End If
            Else
                Beep()
            End If

            Exit Sub
        Else
            Select Case txt
                Case "0" To "9", decPointChar

                Case Else
                    curDMS = selectDMS.degree
            End Select
        End If

        Select Case txt
            Case "log", "ln", "exp", "int", "fix", "frac", "abs", "dtr", "dtg", "rtd", "rtg", "gtd", "gtr"
                txt &= "("

            Case "rnd"
                txt = "round("

            Case "sgn"
                txt = "sign("

            Case "csc"
                txt = "cosec"

            Case "ctn"
                txt = "cotan"

            Case "Exp"
                txt = "E"
        End Select

        Select Case txt
            Case "sin", "cos", "tan", "sec", "cosec", "cotan"
                If cInv.Checked Then
                    'cInv.Checked = False
                    txt = "a" & txt
                End If

                If cHyp.Checked Then
                    'cHyp.Checked = False
                    txt &= "h"
                End If

                txt &= "("
        End Select

        If isModeEdit Then
            Select Case txt
                Case leftPointingChar
                    If pos > 0 Then
                        tDisp.SelectionStart = pos - 1
                    Else
                        tDisp.SelectionStart = tDisp.Text.Length
                    End If

                Case rightPointingChar
                    If pos < tDisp.Text.Length Then
                        tDisp.SelectionStart = pos + 1
                    Else
                        tDisp.SelectionStart = 0
                    End If

                Case "Del"
                    If pos < tDisp.Text.Length Then
                        If l = 0 Then
                            tDisp.SelectionLength = 1
                        End If
                        delSelection()
                    Else
                        Beep()
                    End If

                Case "BS"
                    If pos > 0 Then
                        If l = 0 Then
                            tDisp.SelectionStart = pos - 1
                            tDisp.SelectionLength = 1
                        End If
                        delSelection()
                    Else
                        Beep()
                    End If

                Case "Home"
                    If tDisp.SelectionStart <> 0 Then
                        tDisp.SelectionStart = 0
                        tDisp.SelectionLength = 0
                    End If

                Case "End"
                    If tDisp.SelectionStart <> tDisp.Text.Length Then
                        tDisp.SelectionStart = tDisp.Text.Length
                    End If

                Case Else
                    If txt = decPointChar Then
                        If pos > 0 Then
                            Select Case Mid(tDisp.Text, pos, 1)
                                Case "0" To "9"

                                Case Else
                                    txt = "0" & decPointChar
                            End Select
                        Else
                            txt = "0" & decPointChar
                        End If
                    End If

                    insertText(txt)
            End Select
        Else
            setModeEdit()

            Select Case txt
                Case leftPointingChar, rightPointingChar, "Del", "BS", "CLS", "Home", "End"
                    GoTo returnSHIFTstate
            End Select

            tDisp.Text = ""

            Select Case txt
                Case "0" To "9", "(", ")", "e", piChar, "rand", "ans"

                Case decPointChar
                    txt = "0" & txt

                Case multiplyChar, "/", "^", plusSignChar, minusSignChar, "!", "mod", "dtid"
                    If result <> 0 Then
                        txt = CStr(result) & txt
                    End If

                Case Else
                    If result <> 0 Then
                        txt &= CStr(result)
                    End If
            End Select

            insertText(txt)
        End If

returnSHIFTstate:
        If cSHIFT.Checked Then
            cSHIFT.Checked = False
            setButtonText()
        End If
    End Sub

#End Region

#Region " Other Procedures... "

    Private Sub setButtonText()
        cInv.Enabled = cSHIFT.Checked
        cHyp.Enabled = cSHIFT.Checked

        If isModeEdit Or result <> 0 Or lDisp.Text = "0" Then
            cMem.Enabled = Not cSHIFT.Checked
        End If

        If cSHIFT.Checked Then
            bOpen.Text = "e"
            bClose.Text = piChar
            bLeft.Text = "Home"
            bRight.Text = "End"
            bDel.Text = "rand"
            bBS.Text = "dtid"
            b7.Text = "sin"
            b8.Text = "cos"
            b9.Text = "tan"
            bSqrt.Text = "dtr"
            bPower.Text = "rtd"
            bCLS.Text = "gtd"
            b4.Text = "sec"
            b5.Text = "csc"
            b6.Text = "ctn"
            bMul.Text = "dtg"
            bDiv.Text = "rtg"
            bFact.Text = "gtr"
            b1.Text = "int"
            b2.Text = "fix"
            b3.Text = "frac"
            bPlus.Text = "abs"
            bMin.Text = "rnd"
            bMod.Text = "sgn"
            b0.Text = "log"
            bDP.Text = "ln"
            bExp.Text = "exp"
            bDMS.Text = "ans"
        Else
            bOpen.Text = "("
            bClose.Text = ")"
            bLeft.Text = leftPointingChar
            bRight.Text = rightPointingChar
            bDel.Text = "Del"
            bBS.Text = "BS"
            b7.Text = "7"
            b8.Text = "8"
            b9.Text = "9"
            bSqrt.Text = sqrtChar
            bPower.Text = "^"
            bCLS.Text = "CLS"
            b4.Text = "4"
            b5.Text = "5"
            b6.Text = "6"
            bMul.Text = multiplyChar
            bDiv.Text = "/"
            bFact.Text = "!"
            b1.Text = "1"
            b2.Text = "2"
            b3.Text = "3"
            bPlus.Text = plusSignChar
            bMin.Text = minusSignChar
            bMod.Text = "mod"
            b0.Text = "0"
            bDP.Text = decPointChar
            bExp.Text = "Exp"
            bDMS.Text = degreeChar & " " & minuteChar & " " & secondChar
        End If
    End Sub

    Private Sub initAbout()
        prgDesc = Chr(Keys.S) & Chr(Keys.C + 32) & Chr(Keys.I + 32) & Chr(Keys.E + 32) & Chr(Keys.N + 32) & _
                  Chr(Keys.T + 32) & Chr(Keys.I + 32) & Chr(Keys.F + 32) & Chr(Keys.I + 32) & Chr(Keys.C + 32) & _
                  Chr(Keys.Space) & _
                  Chr(Keys.C) & Chr(Keys.A + 32) & Chr(Keys.L + 32) & Chr(Keys.C + 32) & Chr(Keys.U + 32) & _
                  Chr(Keys.L + 32) & Chr(Keys.A + 32) & Chr(Keys.T + 32) & Chr(Keys.O + 32) & Chr(Keys.R + 32)

        prgVer = Chr(Keys.V) & Chr(Keys.E + 32) & Chr(Keys.R + 32) & Chr(Keys.S + 32) & Chr(Keys.I + 32) & _
                 Chr(Keys.O + 32) & Chr(Keys.N + 32) & _
                 Chr(Keys.Space) & _
                 Chr(Keys.D1) & Chr(Keys.Delete) & Chr(Keys.D0)

        myName = Chr(Keys.I) & Chr(Keys.S + 32) & Chr(Keys.K + 32) & Chr(Keys.A + 32) & Chr(Keys.N + 32) & _
                 Chr(Keys.D + 32) & Chr(Keys.A + 32) & Chr(Keys.R + 32) & _
                 Chr(Keys.Space) & _
                 Chr(Keys.Z) & Chr(46) & _
                 Chr(Keys.Space) & _
                 Chr(Keys.N) & Chr(Keys.A + 32) & Chr(Keys.S + 32) & Chr(Keys.I + 32) & Chr(Keys.B + 32) & _
                 Chr(Keys.U + 32)

        prgCright = Chr(Keys.G) & Chr(Keys.O + 32) & Chr(Keys.R + 32) & Chr(Keys.O + 32) & Chr(Keys.N + 32) & _
                    Chr(Keys.T + 32) & Chr(Keys.A + 32) & Chr(Keys.L + 32) & Chr(Keys.O + 32) & Chr(44) & _
                    vbCrLf & _
                    Chr(Keys.A) & Chr(Keys.P + 32) & Chr(Keys.R + 32) & Chr(Keys.I + 32) & Chr(Keys.L + 32) & _
                    Chr(Keys.Space) & _
                    Chr(Keys.D2) & Chr(Keys.D0) & Chr(Keys.D0) & Chr(Keys.D7) & Chr(46)

        herName = Chr(Keys.A) & Chr(Keys.I + 32) & Chr(Keys.N + 32) & Chr(Keys.A + 32) & Chr(Keys.Space) & _
                  Chr(Keys.K) & Chr(Keys.L + 32) & Chr(Keys.A + 32) & Chr(Keys.I + 32) & Chr(Keys.N + 32) & _
                  Chr(Keys.A + 32)

        myCode1 = Chr(Keys.Z + 32) & Chr(Keys.U + 32) & Chr(Keys.L + 32)

        myCode2 = Chr(Keys.Z + 32) & Chr(Keys.U + 32) & Chr(Keys.L + 32) & Chr(Keys.N + 32) & Chr(Keys.S + 32)

        herCode1 = Chr(Keys.A + 32) & Chr(Keys.K + 32)

        herCode2 = Chr(Keys.A + 32) & Chr(Keys.K + 32) & Chr(Keys.D5) & Chr(Keys.D1)
    End Sub

    Private Sub setModeEdit()
        isModeEdit = True

        cMem.Text = "M Out"

        If Not cMem.Enabled Then
            cMem.Enabled = True
        End If

        If Not cGroup.Enabled Then
            cGroup.Enabled = True
        End If

        If Not cDMS.Enabled Then
            cDMS.Enabled = True
        End If

        tDisp.BringToFront()
    End Sub

    Private Sub setModeDisp()
        isModeEdit = False

        cMem.Text = "M In"

        If lDisp.Text = "" Then
            If cDMS.Checked Then
                lDisp.Text = getDMS(result)
            Else
                If cGroup.Checked Then
                    lDisp.Text = getDigitGroup(result)
                Else
                    lDisp.Text = CStr(result)
                End If
            End If
        Else
            cMem.Enabled = False
            cGroup.Enabled = False
            cDMS.Enabled = False
            Beep()
        End If

        lDisp.BringToFront()
    End Sub

    Private Function getFraction(ByVal num As Double) As Double
        Return num - Fix(num)
    End Function

    Private Function getCharPos(ByVal aString As String, ByVal aChar As String) As Integer
        Dim i As Integer

        If aString.Length >= 1 Then
            For i = 1 To aString.Length
                If aChar = Mid(aString, i, 1) Then
                    Return i
                End If
            Next
        End If

        Return 0
    End Function

    Private Function getDigitGroup(ByVal num As Double) As String
        If Abs(num) < 1000.0# Or Abs(num) >= 1.0E+15 Then
            Return CStr(num)
        End If

        Return Strings.FormatNumber(CStr(num))
    End Function

    Private Function getDMS(ByVal num As Double) As String
        If Abs(num) > 1.0E+15 Then
            Return CStr(num)
        End If

        Dim d As Double, m As Double, s As Double, dms As String

        d = Fix(num)
        num = getFraction(Abs(num)) * 60.0#
        m = Fix(num)
        s = getFraction(num) * 60.0#

        If d <> 0.0# Then
            dms = CStr(d) & degreeChar
        End If

        If m <> 0.0# Then
            dms &= CStr(m) & minuteChar
        End If

        If s <> 0.0# Then
            dms &= CStr(Round(s, 2)) & secondChar
        End If

        Return dms
    End Function

    Private Sub delSelection()
        Dim pos As Integer = tDisp.SelectionStart
        Dim l As Integer = tDisp.SelectionLength

        tDisp.Text = Microsoft.VisualBasic.Left(tDisp.Text, pos) & Mid(tDisp.Text, pos + l + 1)
        tDisp.SelectionStart = pos
    End Sub

    Private Sub insertText(ByVal txt As String)
        delSelection()

        Dim pos As Integer = tDisp.SelectionStart

        tDisp.Text = tDisp.Text.Insert(pos, txt)
        tDisp.SelectionStart = pos + txt.Length
        tDisp.Focus()
    End Sub

    Private Sub expandTokens(ByVal txt As String)
        tokensCtr += 1
        ReDim Preserve tokens(tokensCtr)
        tokens(tokensCtr) = txt
    End Sub

    Private Function fixNumber(ByRef num As String) As Boolean
        If IsNumeric(num) Then
            num = CStr(CDbl(num))
            Return True
        End If

        Dim dPos As Integer = num.IndexOf(degreeChar) + 1
        Dim mPos As Integer = num.IndexOf(minuteChar) + 1
        Dim sPos As Integer = num.IndexOf(secondChar) + 1

        If sPos <> 0 And (sPos < mPos Or sPos < dPos) Then
            Return False
        End If

        If mPos <> 0 And mPos < dPos Then
            Return False
        End If

        Dim dStr As String = "", mStr As String = "", sStr As String = ""

        If dPos > 0 Then
            dStr = Mid(num, 1, dPos - 1)
            If Not IsNumeric(dStr) Then
                Return False
            End If
        End If

        If mPos > 0 Then
            mStr = Mid(num, dPos + 1, mPos - dPos - 1)
            If Not IsNumeric(mStr) Then
                Return False
            End If
        End If

        If sPos > 0 Then
            If mPos > 0 Then
                sStr = Mid(num, mPos + 1, sPos - mPos - 1)
            Else
                sStr = Mid(num, dPos + 1, sPos - dPos - 1)
            End If

            If Not IsNumeric(sStr) Then
                Return False
            End If
        End If

        If dStr.Length + mStr.Length + sStr.Length + Sign(dPos) + Sign(mPos) + Sign(sPos) <> num.Length Then
            Return False
        End If

        Dim d As Double, m As Double, s As Double

        If dPos > 0 Then
            d = CDbl(dStr)
        End If

        If mPos > 0 Then
            m = CDbl(mStr)
        End If

        If sPos > 0 Then
            s = CDbl(sStr)
        End If

        num = CStr(d + m / 60.0# + s / 3600.0#)

        Return True
    End Function

    Private Function checkFunction(ByRef txt As String) As Boolean
        txt = txt.ToLower

        Select Case txt
            Case "m0" To "m9", "ans", "e", "pi", piChar, "mod", "dtid"
            Case "sin", "sinh", "asin", "asinh"
            Case "cos", "cosh", "acos", "acosh"
            Case "tan", "tanh", "atan", "atanh"
            Case "sec", "sech", "asec", "asech"
            Case "cosec", "cosech", "acosec", "acosech"
            Case "cotan", "cotanh", "acotan", "acotanh"
            Case "dtr", "dtg", "rtd", "rtg", "gtd", "gtr"
            Case "rand", "int", "fix", "frac", "abs", "round", "sign", "log", "ln", "exp", "sqrt"
            Case Else
                Return False
        End Select

        Return True
    End Function

    Private Function getTextFromTokens() As String
        Dim txt As String, i As Integer

        If tokensCtr > -1 Then
            For i = 0 To tokensCtr
                If tokens(i) = additionOperatorChar Or tokens(i) = substractionOperatorChar Then
                    txt &= Microsoft.VisualBasic.Right(tokens(i), 1)
                Else
                    txt &= tokens(i)
                End If
            Next
        End If

        Return txt
    End Function

    Private Function getTotalTokensLength(ByVal idx As Integer) As Integer
        If idx < 0 Then
            Return 0
        End If

        Dim i As Integer, pos As Integer

        For i = 0 To idx
            If tokens(i) = additionOperatorChar Or tokens(i) = substractionOperatorChar Then
                pos += 1
            Else
                pos += tokens(i).Length
            End If
        Next

        Return pos
    End Function

    Private Function getCharClasify(ByVal itsChar As String, ByVal prvClas As charClasify) As charClasify
        Select Case itsChar
            Case "0" To "9"
                Select Case prvClas
                    Case charClasify.decPoint, charClasify.digitDec
                        Return charClasify.digitDec

                    Case charClasify.exponent, charClasify.expSign, charClasify.digitExp
                        Return charClasify.digitExp

                    Case charClasify.degree, charClasify.digitMin
                        Return charClasify.digitMin

                    Case charClasify.minute, charClasify.digitSec
                        Return charClasify.digitSec

                    Case charClasify.funct
                        If tokens(tokensCtr) = "mod" Or tokens(tokensCtr) = "dtid" Then
                            Return charClasify.digit
                        Else
                            Return charClasify.funct
                        End If

                    Case Else
                        Return charClasify.digit
                End Select

            Case decPointChar
                Return charClasify.decPoint

            Case "e"
                Select Case prvClas
                    Case charClasify.digit, charClasify.decPoint, charClasify.digitDec
                        Return charClasify.exponent
                    Case Else
                        Return charClasify.funct
                End Select

            Case plusSignChar, minusSignChar
                Select Case prvClas
                    Case charClasify.exponent, charClasify.expSign
                        Return charClasify.expSign
                    Case charClasify.begin, charClasify.leftBracket, charClasify.operator, charClasify.sqrt, _
                    charClasify.sign
                        Return charClasify.sign
                    Case Else
                        Return charClasify.signOp
                End Select

            Case degreeChar
                Return charClasify.degree

            Case minuteChar
                Return charClasify.minute

            Case secondChar
                Return charClasify.second

            Case sqrtChar
                Return charClasify.sqrt

            Case "!"
                Return charClasify.fact

            Case "^", multiplyChar, "/"
                Return charClasify.operator

            Case "("
                Return charClasify.leftBracket

            Case ")"
                Return charClasify.rightBracket

            Case Else
                Return charClasify.funct
        End Select
    End Function

    Private Function parseExpression() As Boolean
        Dim c As String
        Dim i As Integer, prtsCtr As Integer
        Dim prvClas As charClasify, curClas As charClasify = charClasify.begin
        ReDim tokens(0)
        tokensCtr = -1

        For i = 1 To tDisp.Text.Length
            prvClas = curClas
            c = Mid(tDisp.Text, i, 1).ToLower
            curClas = getCharClasify(c, prvClas)

            If prvClas < charClasify.begin And curClas >= charClasify.begin Then
                If Not fixNumber(tokens(tokensCtr)) Then
                    GoTo returnBadNumberError
                End If
            End If

            If prvClas = charClasify.funct And curClas <> charClasify.funct Then
                If Not checkFunction(tokens(tokensCtr)) Then
                    GoTo returnBadFunctionError
                End If
            End If

            If curClas < charClasify.begin Then
                If prvClas < charClasify.begin Or prvClas = charClasify.sign Then
                    tokens(tokensCtr) &= c
                Else
                    expandTokens(c)
                End If
                If i = tDisp.Text.Length Then
                    If Not fixNumber(tokens(tokensCtr)) Then
                        GoTo returnBadNumberError
                    End If
                End If
            End If

            If curClas = charClasify.funct Then
                If prvClas = charClasify.funct Then
                    tokens(tokensCtr) &= c
                Else
                    If prvClas = charClasify.sign Then
                        If tokens(tokensCtr) = plusSignChar Then
                            tokens(tokensCtr) = c
                        Else
                            expandTokens(c)
                        End If
                    Else
                        expandTokens(c)
                    End If
                End If
                If i = tDisp.Text.Length Then
                    If Not checkFunction(tokens(tokensCtr)) Then
                        GoTo returnBadFunctionError
                    End If
                End If
            End If

            If curClas = charClasify.sign Then
                If prvClas = curClas Then
                    If tokens(tokensCtr) = plusSignChar Then
                        If c = minusSignChar Then
                            tokens(tokensCtr) = minusSignChar
                        End If
                    Else
                        If c = minusSignChar Then
                            tokens(tokensCtr) = plusSignChar
                        End If
                    End If
                Else
                    expandTokens(c)
                End If
            End If

            If curClas = charClasify.signOp Then
                If prvClas = curClas Then
                    If tokens(tokensCtr) = additionOperatorChar Then
                        If c = minusSignChar Then
                            tokens(tokensCtr) = substractionOperatorChar
                        End If
                    Else
                        If c = minusSignChar Then
                            tokens(tokensCtr) = additionOperatorChar
                        End If
                    End If
                Else
                    expandTokens(Microsoft.VisualBasic.Left(additionOperatorChar, 1) & c)
                End If
            End If

            If curClas = charClasify.sqrt Then
                If prvClas = charClasify.sign Then
                    If tokens(tokensCtr) = plusSignChar Then
                        tokens(tokensCtr) = c
                    Else
                        expandTokens(c)
                    End If
                Else
                    expandTokens(c)
                End If
            End If

            If curClas = charClasify.fact Or curClas = charClasify.operator Then
                expandTokens(c)
            End If

            If curClas = charClasify.leftBracket Then
                prtsCtr += 1

                If prvClas = charClasify.sign Then
                    If tokens(tokensCtr) = plusSignChar Then
                        tokens(tokensCtr) = c
                    Else
                        expandTokens(c)
                    End If
                Else
                    expandTokens(c)
                End If
            End If

            If curClas = charClasify.rightBracket Then
                prtsCtr -= 1

                If prtsCtr < 0 Then
                    GoTo returnBadParentheses
                End If

                expandTokens(c)
            End If
        Next

        If prtsCtr > 0 Then
            For i = 1 To prtsCtr
                expandTokens(")")
            Next
        End If

        tDisp.Text = getTextFromTokens()
        Return True

returnBadParentheses:
        lDisp.Text = "Bad parentheses"
        GoTo returnError

returnBadNumberError:
        lDisp.Text = "Bad number"
        GoTo returnError

returnBadFunctionError:
        Select Case tokens(tokensCtr)
            Case myCode1, myCode2, herCode1, herCode2
                tDisp.Text = ""
                i = 1

                Select Case tokens(tokensCtr)
                    Case myCode1, myCode2
                        lDisp.Text = myName

                    Case Else
                        lDisp.Text = herName
                End Select

            Case Else
                lDisp.Text = "Unknown function"
        End Select

returnError:
        result = 0

        If i < tDisp.Text.Length Then
            i -= 1
        End If

        tDisp.SelectionStart = i
        ReDim tokens(0)
        Return False
    End Function

    Private Function checkTokens() As Boolean
        Dim i As Integer

        For i = 0 To tokensCtr
            If i = 0 Then
                Select Case getTokenArg(tokens(i))
                    Case tokenArg.funcFact, tokenArg.opMod, tokenArg.opMulDiv, tokenArg.opPower, tokenArg.opD2ID
                        GoTo returnSyntaxError
                End Select
            End If

            If i = tokensCtr Then
                Select Case getTokenArg(tokens(i))
                    Case tokenArg.mathFunction, tokenArg.funcSqrt
                        GoTo returnNoEntryForFunction

                    Case tokenArg.sign, tokenArg.opPower, tokenArg.opMulDiv, tokenArg.opMod, _
                    tokenArg.opPlusMinus, tokenArg.opD2ID
                        GoTo returnSyntaxError
                End Select
            End If

            If getTokenArg(tokens(i)) = tokenArg.mathFunction Then
                If getTokenArg(tokens(i + 1)) <> tokenArg.leftBracket Then
                    GoTo returnNoEntryForFunction
                End If
            End If

            If i > 0 Then
                Select Case getTokenArg(tokens(i))
                    Case tokenArg.digit, tokenArg.variable
                        Select Case getTokenArg(tokens(i - 1))
                            Case tokenArg.funcFact, tokenArg.rightBracket
                                GoTo returnSyntaxError
                        End Select

                    Case tokenArg.mathFunction
                        Select Case getTokenArg(tokens(i - 1))
                            Case tokenArg.rightBracket, tokenArg.funcFact
                                GoTo returnSyntaxError
                        End Select

                    Case tokenArg.leftBracket
                        Select Case getTokenArg(tokens(i - 1))
                            Case tokenArg.digit, tokenArg.variable, tokenArg.funcFact, tokenArg.rightBracket
                                GoTo returnSyntaxError
                        End Select

                    Case tokenArg.rightBracket
                        Select Case getTokenArg(tokens(i - 1))
                            Case tokenArg.leftBracket
                                GoTo returnNoArgumentInParentheses

                            Case tokenArg.digit, tokenArg.variable, tokenArg.funcFact

                            Case Else
                                GoTo returnSyntaxError
                        End Select

                    Case tokenArg.funcFact
                        Select Case getTokenArg(tokens(i - 1))
                            Case tokenArg.digit, tokenArg.variable, tokenArg.rightBracket, tokenArg.funcFact

                            Case Else
                                GoTo returnSyntaxError
                        End Select

                    Case tokenArg.funcSqrt
                        Select Case getTokenArg(tokens(i - 1))
                            Case tokenArg.digit, tokenArg.variable, tokenArg.rightBracket, tokenArg.funcFact
                                GoTo returnSyntaxError
                        End Select

                    Case tokenArg.opPower, tokenArg.opMulDiv, tokenArg.opMod, tokenArg.opPlusMinus, _
                    tokenArg.opD2ID
                        Select Case getTokenArg(tokens(i - 1))
                            Case tokenArg.opPower, tokenArg.opMulDiv, tokenArg.opMod, tokenArg.opPlusMinus, _
                            tokenArg.leftBracket, tokenArg.opD2ID, tokenArg.funcSqrt
                                GoTo returnSyntaxError
                        End Select
                End Select
            End If
        Next

        tDisp.Text = getTextFromTokens()
        tDisp.SelectionStart = tDisp.Text.Length
        Return True

returnNoArgumentInParentheses:
        lDisp.Text = "No argument in parentheses"
        i -= 1
        GoTo returnError

returnNoEntryForFunction:
        lDisp.Text = "No entry for function"
        GoTo returnError

returnSyntaxError:
        lDisp.Text = "Bad expression"
        GoTo returnError

returnError:
        result = 0
        tDisp.SelectionStart = getTotalTokensLength(i)
        ReDim tokens(0)
        Return False
    End Function

    Private Function dispDecToIntDivItr(ByVal ent As Double, ByVal num As Integer, ByVal div As Integer, _
    ByVal itr As Integer, Optional ByVal showLastItr As Boolean = False) As Boolean
        Dim msg As String, isExact As Boolean = False

        If CDbl(num / div) = ent Then
            isExact = True
            msg = "[Exactly]"
        Else
            msg = "(Vicinity)"
        End If

        msg = "Iteration = " & CStr(itr) & vbCrLf & _
              "Input = " & CStr(ent) & vbCrLf & _
              CStr(num) & " / " & CStr(div) & " = " & CStr(CDbl(num / div)) & vbCrLf & _
              msg

        If Not isExact And Not showLastItr Then
            msg &= vbCrLf & "Show next iteration?"
        End If

        If isExact Or showLastItr Then
            MsgBox(msg)
        Else
            If MsgBox(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Function getValueFromMathOperation(ByVal num1 As Double, ByVal num2 As Double, _
    ByVal operation As String, ByRef result As Double, ByRef errMsg As String) As Boolean
        Try
            Select Case operation
                Case "dtid"
                    Dim i As Integer = 1
                    Dim itr As Integer = CInt(Abs(Fix(num2)))
                    Dim num As Double, intNum As Long
                    Dim intNum1 As Long, intNum2 As Long, intNum3 As Integer
                    Dim divNum1 As Long, divNum2 As Long, divNum3 As Integer
                    Dim showNext As Boolean

                    If itr < 2 Then itr = 10

                    tDisp.Text = CStr(num1) & operation & CStr(itr)
                    tDisp.SelectionStart = tDisp.Text.Length

                    num = num1
                    intNum = CLng(Fix(num))
                    intNum1 = intNum
                    divNum1 = 1

                    showNext = dispDecToIntDivItr(num1, intNum1, divNum1, i)

                    i += 1
                    num = 1.0# / getFraction(num)
                    intNum = CLng(Fix(num))
                    intNum2 = intNum * intNum1 + 1
                    divNum2 = intNum

                    If showNext Then
                        showNext = dispDecToIntDivItr(num1, intNum2, divNum2, i)
                    End If

                    If CDbl(intNum2 / divNum2) <> num1 Then
                        For i = 3 To itr
                            num = 1.0# / getFraction(num)
                            intNum = CLng(Fix(num))
                            intNum3 = intNum * intNum2 + intNum1
                            divNum3 = intNum * divNum2 + divNum1

                            If showNext Then
                                showNext = dispDecToIntDivItr(num1, intNum3, divNum3, i, i = itr)
                            End If

                            If CDbl(intNum3 / divNum3) = num1 Then
                                Exit For
                            End If

                            intNum1 = intNum2
                            intNum2 = intNum3
                            divNum1 = divNum2
                            divNum2 = divNum3
                        Next

                        If i > itr Then
                            i = itr
                        End If
                    Else
                        intNum3 = intNum2
                        divNum3 = divNum2
                    End If

                    If Not showNext Then
                        dispDecToIntDivItr(num1, intNum3, divNum3, i, True)
                    End If

                    If CDbl(intNum3 / divNum3) = num1 Then
                        errMsg = " [" & CStr(i) & "]"
                    Else
                        errMsg = " (" & CStr(i) & ")"
                    End If

                    errMsg = CStr(intNum3) & " / " & CStr(divNum3) & errMsg
                    Return False

                Case substractionOperatorChar
                    result = num1 - num2

                Case additionOperatorChar
                    result = num1 + num2

                Case "mod"
                    result = num1 Mod num2

                Case "/"
                    result = num1 / num2

                Case multiplyChar
                    result = num1 * num2

                Case "^"
                    result = num1 ^ num2

                Case minusSignChar
                    result = -result

                Case plusSignChar
                    result = result

                Case sqrtChar, "sqrt"
                    result = Sqrt(num2)

                Case "!"
                    Dim i As Integer
                    Dim up As Integer = CInt(Fix(num2))

                    If up < 0 Then
                        errMsg = "Invalid input for function"
                        Return False
                    End If

                    result = 1.0#

                    If up = 0 Then
                        Return True
                    End If

                    For i = 1 To up
                        result = result * CDbl(i)
                    Next

                Case "abs"
                    result = Abs(num2)

                Case "exp"
                    result = Exp(num2)

                Case "fix"
                    result = Fix(num2)

                Case "frac"
                    result = getFraction(num2)

                Case "int"
                    result = Int(num2)

                Case "ln"
                    result = Log(num2)

                Case "log"
                    result = Log10(num2)

                Case "round"
                    result = Round(num2)

                Case "sign"
                    result = CDbl(Sign(result))

                Case "dtr"
                    result = num2 / 180.0# * CDbl(PI)

                Case "dtg"
                    result = num2 / 180.0# * 200.0#

                Case "rtd"
                    result = num2 / CDbl(PI) * 180.0#

                Case "rtg"
                    result = num2 / CDbl(PI) * 200.0#

                Case "gtd"
                    result = num2 / 200.0# * 180.0#

                Case "gtr"
                    result = num2 / 200.0# * CDbl(PI)

                Case "sinh"
                    'Hyperbolic Sine HSin(X) = (Exp(X) – Exp(-X)) / 2
                    result = (Exp(num2) - Exp(-num2)) / 2.0#
                    'result = Sinh(num2)

                Case "cosh"
                    'Hyperbolic Cosine HCos(X) = (Exp(X) + Exp(-X)) / 2
                    result = (Exp(num2) + Exp(-num2)) / 2.0#
                    'result = Cosh(num2)

                Case "tanh"
                    'Hyperbolic Tangent HTan(X) = (Exp(X) – Exp(-X)) / (Exp(X) + Exp(-X))
                    result = (Exp(num2) - Exp(-num2)) / (Exp(num2) + Exp(-num2))
                    'result = Tanh(num2)

                Case "asinh"
                    'Inverse Hyperbolic Sine HArcsin(X) = Log(X + Sqr(X * X + 1))
                    result = Log(num2 + Sqrt(num2 * num2 + 1.0#))

                Case "acosh"
                    'Inverse Hyperbolic Cosine HArccos(X) = Log(X + Sqr(X * X – 1))
                    result = Log(num2 + Sqrt(num2 * num2 - 1.0#))

                Case "atanh"
                    'Inverse Hyperbolic Tangent HArctan(X) = Log((1 + X) / (1 – X)) / 2
                    result = Log((1.0# + num2) / (1.0# - num2)) / 2.0#

                Case "sech"
                    'Hyperbolic Secant HSec(X) = 2 / (Exp(X) + Exp(-X))
                    result = 2.0# / (Exp(num2) + Exp(-num2))

                Case "cosech"
                    'Hyperbolic Cosecant HCosec(X) = 2 / (Exp(X) – Exp(-X))
                    result = 2.0# / (Exp(num2) - Exp(-num2))

                Case "cotanh"
                    'Hyperbolic Cotangent HCotan(X) = (Exp(X) + Exp(-X)) / (Exp(X) – Exp(-X))
                    result = (Exp(num2) + Exp(-num2)) / (Exp(num2) - Exp(-num2))

                Case "asech"
                    'Inverse Hyperbolic Secant HArcsec(X) = Log((Sqr(-X * X + 1) + 1) / X)
                    result = Log((Sqrt(-num2 * num2 + 1.0#) + 1.0#) / num2)

                Case "acosech"
                    'Inverse Hyperbolic Cosecant HArccosec(X) = Log((Sgn(X) * Sqr(X * X + 1) + 1) / X)
                    result = Log((CDbl(Sign(num2)) * Sqrt(num2 * num2 + 1.0#) + 1.0#) / num2)

                Case "acotanh"
                    'Inverse Hyperbolic Cotangent HArccotan(X) = Log((X + 1) / (X – 1)) / 2
                    result = Log((num2 + 1.0#) / (num2 - 1.0#)) / 2.0#

                Case "sin", "cos", "tan", "sec", "cosec", "cotan"
                    If rDeg.Checked Then
                        num2 = num2 / 180.0# * CDbl(PI)
                    ElseIf rGra.Checked Then
                        num2 = num2 / 200.0# * CDbl(PI)
                    End If

                    Select Case operation
                        Case "sin"
                            result = Sin(num2)

                        Case "cos"
                            result = Cos(num2)

                        Case "tan"
                            result = Tan(num2)

                        Case "sec"
                            'Secant Sec(X) = 1 / Cos(X)
                            result = 1.0# / Cos(num2)

                        Case "cosec"
                            'Cosecant Cosec(X) = 1 / Sin(X)
                            result = 1.0# / Sin(num2)

                        Case "cotan"
                            'Cotangent Cotan(X) = 1 / Tan(X)
                            result = 1.0# / Tan(num2)
                    End Select

                Case "asin", "acos", "atan", "asec", "acosec", "acotan"
                    Select Case operation
                        Case "asin"
                            result = Asin(num2)

                        Case "acos"
                            result = Acos(num2)

                        Case "atan"
                            result = Atan(num2)

                        Case "asec"
                            'Inverse Secant Arcsec(X) = Atn(X / Sqr(X * X – 1)) + Sgn((X) – 1) * (2 * Atn(1))
                            result = Atan(num2 / Sqrt(num2 * num2 - 1.0#)) + _
                                     CDbl(Sign(num2 - 1.0#)) * 2.0# * Atan(1.0#)

                        Case "acosec"
                            'Inverse Cosecant Arccosec(X) = Atn(X / Sqr(X * X - 1)) + (Sgn(X) – 1) * (2 * Atn(1))
                            result = Atan(num2 / Sqrt(num2 * num2 - 1.0#)) + _
                                     (CDbl(Sign(num2)) - 1.0#) * 2.0# * Atan(1.0#)

                        Case "acotan"
                            'Inverse Cotangent Arccotan(X) = Atn(X) + 2 * Atn(1)
                            result = Atan(num2) + 2.0# * Atan(1.0#)
                    End Select

                    If rDeg.Checked Then
                        result = result / PI * 180.0#
                    ElseIf rGra.Checked Then
                        result = result / PI * 200.0#
                    End If
            End Select

            Select Case CStr(result)
                Case "Infinity"
                    errMsg = CStr(result)

                Case "NaN"
                    errMsg = "Invalid input for function"

                Case Else
                    Return True
            End Select

            Return False

        Catch ex As Exception
            errMsg = ex.Message
            Return False
        End Try
    End Function

    Private Function getTokenArg(ByVal tkn As String) As tokenArg
        Select Case tkn
            Case ")"
                Return tokenArg.rightBracket

            Case additionOperatorChar, substractionOperatorChar
                Return tokenArg.opPlusMinus

            Case "mod"
                Return tokenArg.opMod

            Case "dtid"
                Return tokenArg.opD2ID

            Case multiplyChar, "/"
                Return tokenArg.opMulDiv

            Case "^"
                Return tokenArg.opPower

            Case sqrtChar
                Return tokenArg.funcSqrt

            Case "!"
                Return tokenArg.funcFact

            Case plusSignChar, minusSignChar
                Return tokenArg.sign

            Case "("
                Return tokenArg.leftBracket

            Case "m0" To "m9", "e", "pi", piChar, "ans"
                Return tokenArg.variable

            Case Else
                If IsNumeric(tkn) Then
                    Return tokenArg.digit
                Else
                    Return tokenArg.mathFunction
                End If
        End Select
    End Function

    Private Sub pushNum(ByVal num As Double)
        numStackCtr += 1
        ReDim Preserve numStack(numStackCtr)
        numStack(numStackCtr) = num
    End Sub

    Private Sub popNum()
        numStackCtr -= 1

        If numStackCtr >= 0 Then
            ReDim Preserve numStack(numStackCtr)
        Else
            ReDim numStack(0)
        End If
    End Sub

    Private Sub pushOp(ByVal op As String)
        opStackCtr += 1
        ReDim Preserve opStack(opStackCtr)
        opStack(opStackCtr) = op
    End Sub

    Private Sub popOp()
        opStackCtr -= 1

        If opStackCtr >= 0 Then
            ReDim Preserve opStack(opStackCtr)
        Else
            ReDim opStack(0)
        End If
    End Sub

    Private Function getResult() As Boolean
        Dim num As Double
        Dim ans As Double = result
        Dim curTknCtr As Integer
        Dim errMsg As String
        numStackCtr = -1
        opStackCtr = -1
        result = 0

        Do
            Select Case getTokenArg(tokens(curTknCtr))
                Case tokenArg.digit
                    result = CDbl(tokens(curTknCtr))

                Case tokenArg.variable
                    Select Case tokens(curTknCtr)
                        Case "m0" To "m9"
                            result = mem(Val(Mid(tokens(curTknCtr), 2)))

                        Case "e"
                            result = CDbl(System.Math.E)

                        Case "pi", piChar
                            result = CDbl(System.Math.PI)

                        Case "rand"
                            Randomize()
                            result = CDbl(Rnd())

                        Case "ans"
                            result = ans
                    End Select

                Case tokenArg.leftBracket, tokenArg.sign, tokenArg.mathFunction, tokenArg.funcSqrt
                    pushOp(tokens(curTknCtr))

                Case tokenArg.funcFact
                    If Not getValueFromMathOperation(num, result, tokens(curTknCtr), result, errMsg) Then
                        GoTo return_Error
                    End If

                Case tokenArg.rightBracket
                    Do
                        If getTokenArg(opStack(opStackCtr)) = tokenArg.leftBracket Then
                            popOp()
                            Exit Do
                        Else
                            If getTokenArg(opStack(opStackCtr)) <> tokenArg.mathFunction _
                            And getTokenArg(opStack(opStackCtr)) <> tokenArg.funcSqrt _
                            And getTokenArg(opStack(opStackCtr)) <> tokenArg.sign Then
                                num = numStack(numStackCtr)
                                popNum()
                            End If
                            If getValueFromMathOperation(num, result, opStack(opStackCtr), result, errMsg) Then
                                popOp()
                            Else
                                GoTo return_Error
                            End If
                        End If
                    Loop

                Case Else
                    Do
                        If opStackCtr = -1 Then
                            Exit Do
                        End If

                        If getTokenArg(opStack(opStackCtr)) = tokenArg.leftBracket _
                        Or getTokenArg(tokens(curTknCtr)) > getTokenArg(opStack(opStackCtr)) Then
                            Exit Do
                        End If

                        If getTokenArg(opStack(opStackCtr)) <> tokenArg.mathFunction _
                        And getTokenArg(opStack(opStackCtr)) <> tokenArg.funcSqrt _
                        And getTokenArg(opStack(opStackCtr)) <> tokenArg.sign Then
                            num = numStack(numStackCtr)
                            popNum()
                        End If

                        If getValueFromMathOperation(num, result, opStack(opStackCtr), result, errMsg) Then
                            popOp()
                        Else
                            GoTo return_Error
                        End If
                    Loop

                    pushNum(result)
                    pushOp(tokens(curTknCtr))
            End Select

            curTknCtr += 1
        Loop While curTknCtr <= tokensCtr

        Do While opStackCtr >= 0
            If getTokenArg(opStack(opStackCtr)) <> tokenArg.mathFunction _
            And getTokenArg(opStack(opStackCtr)) <> tokenArg.funcSqrt _
            And getTokenArg(opStack(opStackCtr)) <> tokenArg.sign Then
                num = numStack(numStackCtr)
                popNum()
            End If

            If getValueFromMathOperation(num, result, opStack(opStackCtr), result, errMsg) Then
                popOp()
            Else
                GoTo return_Error
            End If
        Loop

        lDisp.Text = ""
        Return True

return_Error:
        lDisp.Text = errMsg

        If Mid(lDisp.Text, tDisp.Text.Length) <> ")" Then
            tDisp.SelectionStart = getTotalTokensLength(curTknCtr - 1)
        End If

        result = 0
        ReDim tokens(0)
        ReDim numStack(0)
        ReDim opStack(0)
        Return False
    End Function

#End Region

End Class

# Microsoft Developer Studio Generated NMAKE File, Format Version 4.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Dynamic-Link Library" 0x0102

!IF "$(CFG)" == ""
CFG=tankmfc - Win32 Debug
!MESSAGE No configuration specified.  Defaulting to tankmfc - Win32 Debug.
!ENDIF 

!IF "$(CFG)" != "tankmfc - Win32 Release" && "$(CFG)" !=\
 "tankmfc - Win32 Debug"
!MESSAGE Invalid configuration "$(CFG)" specified.
!MESSAGE You can specify a configuration when running NMAKE on this makefile
!MESSAGE by defining the macro CFG on the command line.  For example:
!MESSAGE 
!MESSAGE NMAKE /f "Tankmfc.mak" CFG="tankmfc - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "tankmfc - Win32 Release" (based on\
 "Win32 (x86) Dynamic-Link Library")
!MESSAGE "tankmfc - Win32 Debug" (based on "Win32 (x86) Dynamic-Link Library")
!MESSAGE 
!ERROR An invalid configuration is specified.
!ENDIF 

!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE 
NULL=nul
!ENDIF 
################################################################################
# Begin Project
# PROP Target_Last_Scanned "tankmfc - Win32 Debug"
CPP=cl.exe
RSC=rc.exe
MTL=mktyplib.exe

!IF  "$(CFG)" == "tankmfc - Win32 Release"

# PROP BASE Use_MFC 6
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "Release"
# PROP BASE Intermediate_Dir "Release"
# PROP BASE Target_Dir ""
# PROP Use_MFC 6
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "Release"
# PROP Intermediate_Dir "Release"
# PROP Target_Dir ""
OUTDIR=.\Release
INTDIR=.\Release

ALL : "$(OUTDIR)\Tankmfc.dll"

CLEAN : 
	-@erase ".\Release\Tankmfc.dll"
	-@erase ".\Release\Stdafx.obj"
	-@erase ".\Release\Tank.obj"
	-@erase ".\Release\Tankinfo.obj"
	-@erase ".\Release\Tankmfc.obj"
	-@erase ".\Release\Tankmfc.res"
	-@erase ".\Release\Tankmfc.lib"
	-@erase ".\Release\Tankmfc.exp"

"$(OUTDIR)" :
    if not exist "$(OUTDIR)/$(NULL)" mkdir "$(OUTDIR)"

# ADD BASE CPP /nologo /MD /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_WINDLL" /D "_AFXDLL" /D "_MBCS" /Yu"stdafx.h" /c
# ADD CPP /nologo /MD /W3 /GX /O2 /I "\vissim30\vsdk\include" /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_WINDLL" /D "_AFXDLL" /D "_MBCS" /D "_USRDLL" /c
# SUBTRACT CPP /YX /Yc /Yu
CPP_PROJ=/nologo /MD /W3 /GX /O2 /I "\vissim30\vsdk\include" /D "WIN32" /D\
 "NDEBUG" /D "_WINDOWS" /D "_WINDLL" /D "_AFXDLL" /D "_MBCS" /D "_USRDLL"\
 /Fo"$(INTDIR)/" /c 
CPP_OBJS=.\Release/
CPP_SBRS=
# ADD BASE MTL /nologo /D "NDEBUG" /win32
# ADD MTL /nologo /D "NDEBUG" /win32
MTL_PROJ=/nologo /D "NDEBUG" /win32 
# ADD BASE RSC /l 0x409 /d "NDEBUG" /d "_AFXDLL"
# ADD RSC /l 0x409 /d "NDEBUG" /d "_AFXDLL"
RSC_PROJ=/l 0x409 /fo"$(INTDIR)/Tankmfc.res" /d "NDEBUG" /d "_AFXDLL" 
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
BSC32_FLAGS=/nologo /o"$(OUTDIR)/Tankmfc.bsc" 
BSC32_SBRS=
LINK32=link.exe
# ADD BASE LINK32 /nologo /subsystem:windows /dll /machine:I386
# ADD LINK32 /nologo /subsystem:windows /dll /machine:I386
LINK32_FLAGS=/nologo /subsystem:windows /dll /incremental:no\
 /pdb:"$(OUTDIR)/Tankmfc.pdb" /machine:I386 /out:"$(OUTDIR)/Tankmfc.dll"\
 /implib:"$(OUTDIR)/Tankmfc.lib" 
LINK32_OBJS= \
	"$(INTDIR)/Stdafx.obj" \
	"$(INTDIR)/Tank.obj" \
	"$(INTDIR)/Tankinfo.obj" \
	"$(INTDIR)/Tankmfc.obj" \
	"$(INTDIR)/Tankmfc.res" \
	"..\..\lib\Vissim32.lib"

"$(OUTDIR)\Tankmfc.dll" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ELSEIF  "$(CFG)" == "tankmfc - Win32 Debug"

# PROP BASE Use_MFC 6
# PROP BASE Use_Debug_Libraries 1
# PROP BASE Output_Dir "Debug"
# PROP BASE Intermediate_Dir "Debug"
# PROP BASE Target_Dir ""
# PROP Use_MFC 5
# PROP Use_Debug_Libraries 1
# PROP Output_Dir "Debug"
# PROP Intermediate_Dir "Debug"
# PROP Target_Dir ""
OUTDIR=.\Debug
INTDIR=.\Debug

ALL : "$(OUTDIR)\Tankmfc.dll" "$(OUTDIR)\Tankmfc.bsc"

CLEAN : 
	-@erase ".\Debug\vc40.pdb"
	-@erase ".\Debug\vc40.idb"
	-@erase ".\Debug\Tankmfc.bsc"
	-@erase ".\Debug\Stdafx.sbr"
	-@erase ".\Debug\Tank.sbr"
	-@erase ".\Debug\Tankinfo.sbr"
	-@erase ".\Debug\Tankmfc.sbr"
	-@erase ".\Debug\Tankmfc.dll"
	-@erase ".\Debug\Stdafx.obj"
	-@erase ".\Debug\Tank.obj"
	-@erase ".\Debug\Tankinfo.obj"
	-@erase ".\Debug\Tankmfc.obj"
	-@erase ".\Debug\Tankmfc.res"
	-@erase ".\Debug\Tankmfc.ilk"
	-@erase ".\Debug\Tankmfc.lib"
	-@erase ".\Debug\Tankmfc.exp"
	-@erase ".\Debug\Tankmfc.pdb"

"$(OUTDIR)" :
    if not exist "$(OUTDIR)/$(NULL)" mkdir "$(OUTDIR)"

# ADD BASE CPP /nologo /MDd /W3 /Gm /GX /Zi /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_WINDLL" /D "_AFXDLL" /D "_MBCS" /Yu"stdafx.h" /c
# ADD CPP /nologo /MTd /W3 /Gm /GX /Zi /Od /I "\vissim30\vsdk\include" /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_USRDLL" /D "_WINDLL" /D "_MBCS" /FR /c
# SUBTRACT CPP /YX /Yc /Yu
CPP_PROJ=/nologo /MTd /W3 /Gm /GX /Zi /Od /I "\vissim30\vsdk\include" /D\
 "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_USRDLL" /D "_WINDLL" /D "_MBCS"\
 /FR"$(INTDIR)/" /Fo"$(INTDIR)/" /Fd"$(INTDIR)/" /c 
CPP_OBJS=.\Debug/
CPP_SBRS=.\Debug/
# ADD BASE MTL /nologo /D "_DEBUG" /win32
# ADD MTL /nologo /D "_DEBUG" /win32
MTL_PROJ=/nologo /D "_DEBUG" /win32 
# ADD BASE RSC /l 0x409 /d "_DEBUG" /d "_AFXDLL"
# ADD RSC /l 0x409 /d "_DEBUG"
RSC_PROJ=/l 0x409 /fo"$(INTDIR)/Tankmfc.res" /d "_DEBUG" 
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
BSC32_FLAGS=/nologo /o"$(OUTDIR)/Tankmfc.bsc" 
BSC32_SBRS= \
	"$(INTDIR)/Stdafx.sbr" \
	"$(INTDIR)/Tank.sbr" \
	"$(INTDIR)/Tankinfo.sbr" \
	"$(INTDIR)/Tankmfc.sbr"

"$(OUTDIR)\Tankmfc.bsc" : "$(OUTDIR)" $(BSC32_SBRS)
    $(BSC32) @<<
  $(BSC32_FLAGS) $(BSC32_SBRS)
<<

LINK32=link.exe
# ADD BASE LINK32 /nologo /subsystem:windows /dll /debug /machine:I386
# ADD LINK32 /nologo /subsystem:windows /dll /debug /machine:I386
LINK32_FLAGS=/nologo /subsystem:windows /dll /incremental:yes\
 /pdb:"$(OUTDIR)/Tankmfc.pdb" /debug /machine:I386 /out:"$(OUTDIR)/Tankmfc.dll"\
 /implib:"$(OUTDIR)/Tankmfc.lib" 
LINK32_OBJS= \
	"$(INTDIR)/Stdafx.obj" \
	"$(INTDIR)/Tank.obj" \
	"$(INTDIR)/Tankinfo.obj" \
	"$(INTDIR)/Tankmfc.obj" \
	"$(INTDIR)/Tankmfc.res" \
	"..\..\lib\Vissim32.lib"

"$(OUTDIR)\Tankmfc.dll" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ENDIF 

.c{$(CPP_OBJS)}.obj:
   $(CPP) $(CPP_PROJ) $<  

.cpp{$(CPP_OBJS)}.obj:
   $(CPP) $(CPP_PROJ) $<  

.cxx{$(CPP_OBJS)}.obj:
   $(CPP) $(CPP_PROJ) $<  

.c{$(CPP_SBRS)}.sbr:
   $(CPP) $(CPP_PROJ) $<  

.cpp{$(CPP_SBRS)}.sbr:
   $(CPP) $(CPP_PROJ) $<  

.cxx{$(CPP_SBRS)}.sbr:
   $(CPP) $(CPP_PROJ) $<  

################################################################################
# Begin Target

# Name "tankmfc - Win32 Release"
# Name "tankmfc - Win32 Debug"

!IF  "$(CFG)" == "tankmfc - Win32 Release"

!ELSEIF  "$(CFG)" == "tankmfc - Win32 Debug"

!ENDIF 

################################################################################
# Begin Source File

SOURCE=\VISSIM30\Vsdk\lib\Vissim32.lib

!IF  "$(CFG)" == "tankmfc - Win32 Release"

!ELSEIF  "$(CFG)" == "tankmfc - Win32 Debug"

!ENDIF 

# End Source File
################################################################################
# Begin Source File

SOURCE=.\Stdafx.cpp
DEP_CPP_STDAF=\
	".\StdAfx.h"\
	

!IF  "$(CFG)" == "tankmfc - Win32 Release"


"$(INTDIR)\Stdafx.obj" : $(SOURCE) $(DEP_CPP_STDAF) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"


!ELSEIF  "$(CFG)" == "tankmfc - Win32 Debug"


"$(INTDIR)\Stdafx.obj" : $(SOURCE) $(DEP_CPP_STDAF) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"

"$(INTDIR)\Stdafx.sbr" : $(SOURCE) $(DEP_CPP_STDAF) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"


!ENDIF 

# End Source File
################################################################################
# Begin Source File

SOURCE=.\Tank.cpp
DEP_CPP_TANK_=\
	".\StdAfx.h"\
	"\vissim30\vsdk\include\vsuser.h"\
	".\Tank.h"\
	".\TankInfo.h"\
	

!IF  "$(CFG)" == "tankmfc - Win32 Release"


"$(INTDIR)\Tank.obj" : $(SOURCE) $(DEP_CPP_TANK_) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"


!ELSEIF  "$(CFG)" == "tankmfc - Win32 Debug"


"$(INTDIR)\Tank.obj" : $(SOURCE) $(DEP_CPP_TANK_) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"

"$(INTDIR)\Tank.sbr" : $(SOURCE) $(DEP_CPP_TANK_) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"


!ENDIF 

# End Source File
################################################################################
# Begin Source File

SOURCE=.\Tankinfo.cpp
DEP_CPP_TANKI=\
	".\StdAfx.h"\
	".\tankmfc.h"\
	".\TankInfo.h"\
	

!IF  "$(CFG)" == "tankmfc - Win32 Release"


"$(INTDIR)\Tankinfo.obj" : $(SOURCE) $(DEP_CPP_TANKI) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"


!ELSEIF  "$(CFG)" == "tankmfc - Win32 Debug"


"$(INTDIR)\Tankinfo.obj" : $(SOURCE) $(DEP_CPP_TANKI) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"

"$(INTDIR)\Tankinfo.sbr" : $(SOURCE) $(DEP_CPP_TANKI) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"


!ENDIF 

# End Source File
################################################################################
# Begin Source File

SOURCE=.\Tankmfc.cpp
DEP_CPP_TANKM=\
	".\StdAfx.h"\
	".\tankmfc.h"\
	

!IF  "$(CFG)" == "tankmfc - Win32 Release"


"$(INTDIR)\Tankmfc.obj" : $(SOURCE) $(DEP_CPP_TANKM) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"


!ELSEIF  "$(CFG)" == "tankmfc - Win32 Debug"


"$(INTDIR)\Tankmfc.obj" : $(SOURCE) $(DEP_CPP_TANKM) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"

"$(INTDIR)\Tankmfc.sbr" : $(SOURCE) $(DEP_CPP_TANKM) "$(INTDIR)"\
 "$(INTDIR)\Tankmfc.pch"


!ENDIF 

# End Source File
################################################################################
# Begin Source File

SOURCE=.\Tankmfc.rc
DEP_RSC_TANKMF=\
	".\res\tankmfc.rc2"\
	

"$(INTDIR)\Tankmfc.res" : $(SOURCE) $(DEP_RSC_TANKMF) "$(INTDIR)"
   $(RSC) $(RSC_PROJ) $(SOURCE)


# End Source File
# End Target
# End Project
################################################################################

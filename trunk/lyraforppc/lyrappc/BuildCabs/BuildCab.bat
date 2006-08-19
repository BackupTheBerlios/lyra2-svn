@echo off
cd "D:\Work\Andreas\lyraforppc\lyrappc\BuildCabs"
rm -f Cabs/*.*
"C:\Programme\Microsoft Visual Studio .NET 2003\CompactFrameworkSDK\v1.0.5000\bin\Cabwiz.exe" lyrappc_PPC.inf /dest "D:\Work\Andreas\lyraforppc\lyrappc\BuildCabs\Cabs" /err CabWiz.PPC.log /cpu ARMV4 ARM SH3 MIPS X86 WCE420X86

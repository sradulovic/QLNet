/*
 Copyright (C) 2008 Toyin Akin (toyin_akin@hotmail.com)
  
 This file is part of QLNet Project https://github.com/amaggiulli/qlnet

 QLNet is free software: you can redistribute it and/or modify it
 under the terms of the QLNet license.  You should have received a
 copy of the license along with this program; if not, license is  
 available online at <http://qlnet.sourceforge.net/License.html>.
  
 QLNet is a based on QuantLib, a free-software/open-source library
 for financial quantitative analysts and developers - http://quantlib.org/
 The QuantLib license is available online at http://quantlib.org/license.shtml.
 
 This program is distributed in the hope that it will be useful, but WITHOUT
 ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 FOR A PARTICULAR PURPOSE.  See the license for more details.
*/
using System;

namespace QLNet {

public static class KronrodintegralArrays
{

   public static double rescaleError(double err, double resultAbs, double resultAsc)
		{
			err = Math.Abs(err);
			if (resultAsc.IsNotEqual(0.0) && err.IsNotEqual(0.0))
			{
				double scale = Math.Pow((200 * err / resultAsc), 1.5);
				if (scale < 1)
					err = resultAsc * scale;
				else
					err = resultAsc;
				}
			if (resultAbs > Double.MinValue / (50 * Double.Epsilon))
			{
				double min_err = 50 * Double.Epsilon * resultAbs;
				if (min_err > err)
					err = min_err;
				}
			return err;
		}

	//     Gauss-Kronrod-Patterson quadrature coefficients for use in
	//    quadpack routine qng. These coefficients were calculated with
	//    101 decimal digit arithmetic by L. W. Fullerton, Bell Labs, Nov
	//    1981. 

		// x1, abscissae common to the 10-, 21-, 43- and 87-point rule 
      private static readonly double[] x1_  = { 0.973906528517171720077964012084452, 0.865063366688984510732096688423493, 0.679409568299024406234327365114874, 0.433395394129247190799265943165784, 0.148874338981631210884826001129720 };
      public static double[] x1 { get { return x1_; } }

		// w10, weights of the 10-point formula 
      private static readonly double[] w10_ = { 0.066671344308688137593568809893332, 0.149451349150580593145776339657697, 0.219086362515982043995534934228163, 0.269266719309996355091226921569469, 0.295524224714752870173892994651338 };
      public static double[] w10 { get { return w10_; } }  

		// x2, abscissae common to the 21-, 43- and 87-point rule 
      private static readonly double[] x2_ = { 0.995657163025808080735527280689003, 0.930157491355708226001207180059508, 0.780817726586416897063717578345042, 0.562757134668604683339000099272694, 0.294392862701460198131126603103866 };
      public static double[] x2 { get { return x2_; } }  

		// w21a, weights of the 21-point formula for abscissae x1 
      private static readonly double[] w21a_ = { 0.032558162307964727478818972459390, 0.075039674810919952767043140916190, 0.109387158802297641899210590325805, 0.134709217311473325928054001771707, 0.147739104901338491374841515972068 };
      public static double[] w21a { get { return w21a_; } } 

		// w21b, weights of the 21-point formula for abscissae x2 
      private static readonly double[] w21b_ = { 0.011694638867371874278064396062192, 0.054755896574351996031381300244580, 0.093125454583697605535065465083366, 0.123491976262065851077958109831074, 0.142775938577060080797094273138717, 0.149445554002916905664936468389821 };
      public static double[] w21b { get { return w21b_; } } 

		// x3, abscissae common to the 43- and 87-point rule 
      private static readonly double[] x3_ = { 0.999333360901932081394099323919911, 0.987433402908088869795961478381209, 0.954807934814266299257919200290473, 0.900148695748328293625099494069092, 0.825198314983114150847066732588520, 0.732148388989304982612354848755461, 0.622847970537725238641159120344323, 0.499479574071056499952214885499755, 0.364901661346580768043989548502644, 0.222254919776601296498260928066212, 0.074650617461383322043914435796506 };
      public static double[] x3 { get { return x3_; } } 

		// w43a, weights of the 43-point formula for abscissae x1, x3 
      private static readonly double[] w43a_ = { 0.016296734289666564924281974617663, 0.037522876120869501461613795898115, 0.054694902058255442147212685465005, 0.067355414609478086075553166302174, 0.073870199632393953432140695251367, 0.005768556059769796184184327908655, 0.027371890593248842081276069289151, 0.046560826910428830743339154433824, 0.061744995201442564496240336030883, 0.071387267268693397768559114425516 };
      public static double[] w43a { get { return w43a_; } } 

		// w43b, weights of the 43-point formula for abscissae x3 
      private static readonly double[] w43b_ = { 0.001844477640212414100389106552965, 0.010798689585891651740465406741293, 0.021895363867795428102523123075149, 0.032597463975345689443882222526137, 0.042163137935191811847627924327955, 0.050741939600184577780189020092084, 0.058379395542619248375475369330206, 0.064746404951445885544689259517511, 0.069566197912356484528633315038405, 0.072824441471833208150939535192842, 0.074507751014175118273571813842889, 0.074722147517403005594425168280423 };
      public static double[] w43b { get { return w43b_; } } 

		// x4, abscissae of the 87-point rule 
      private static readonly double[] x4_ = { 0.999902977262729234490529830591582, 0.997989895986678745427496322365960, 0.992175497860687222808523352251425, 0.981358163572712773571916941623894, 0.965057623858384619128284110607926, 0.943167613133670596816416634507426, 0.915806414685507209591826430720050, 0.883221657771316501372117548744163, 0.845710748462415666605902011504855, 0.803557658035230982788739474980964, 0.757005730685495558328942793432020, 0.706273209787321819824094274740840, 0.651589466501177922534422205016736, 0.593223374057961088875273770349144, 0.531493605970831932285268948562671, 0.466763623042022844871966781659270, 0.399424847859218804732101665817923, 0.329874877106188288265053371824597, 0.258503559202161551802280975429025, 0.185695396568346652015917141167606, 0.111842213179907468172398359241362, 0.037352123394619870814998165437704 };
      public static double[] x4 { get { return x4_; } } 

		// w87a, weights of the 87-point formula for abscissae x1, x2, x3 
      private static readonly double[] w87a_ = { 0.008148377384149172900002878448190, 0.018761438201562822243935059003794, 0.027347451050052286161582829741283, 0.033677707311637930046581056957588, 0.036935099820427907614589586742499, 0.002884872430211530501334156248695, 0.013685946022712701888950035273128, 0.023280413502888311123409291030404, 0.030872497611713358675466394126442, 0.035693633639418770719351355457044, 0.000915283345202241360843392549948, 0.005399280219300471367738743391053, 0.010947679601118931134327826856808, 0.016298731696787335262665703223280, 0.021081568889203835112433060188190, 0.025370969769253827243467999831710, 0.029189697756475752501446154084920, 0.032373202467202789685788194889595, 0.034783098950365142750781997949596, 0.036412220731351787562801163687577, 0.037253875503047708539592001191226 };
      public static double[] w87a { get { return w87a_; } } 

		// w87b, weights of the 87-point formula for abscissae x4 
      private static readonly double[] w87b_ = { 0.000274145563762072350016527092881, 0.001807124155057942948341311753254, 0.004096869282759164864458070683480, 0.006758290051847378699816577897424, 0.009549957672201646536053581325377, 0.012329447652244853694626639963780, 0.015010447346388952376697286041943, 0.017548967986243191099665352925900, 0.019938037786440888202278192730714, 0.022194935961012286796332102959499, 0.024339147126000805470360647041454, 0.026374505414839207241503786552615, 0.028286910788771200659968002987960, 0.030052581128092695322521110347341, 0.031646751371439929404586051078883, 0.033050413419978503290785944862689, 0.034255099704226061787082821046821, 0.035262412660156681033782717998428, 0.036076989622888701185500318003895, 0.036698604498456094498018047441094, 0.037120549269832576114119958413599, 0.037334228751935040321235449094698, 0.037361073762679023410321241766599 };
      public static double[] w87b { get { return w87b_; } }

		// weights for 7-point Gauss-Legendre integration
		// (only 4 values out of 7 are given as they are symmetric)
      private static readonly double[] g7w_ = { 0.417959183673469, 0.381830050505119, 0.279705391489277, 0.129484966168870 };
      public static double[] g7w { get { return g7w_; } }

		// weights for 15-point Gauss-Kronrod integration
      private static readonly double[] k15w_ = { 0.209482141084728, 0.204432940075298, 0.190350578064785, 0.169004726639267, 0.140653259715525, 0.104790010322250, 0.063092092629979, 0.022935322010529 };
      public static double[] k15w { get { return k15w_; } }

		// abscissae (evaluation points)
		// for 15-point Gauss-Kronrod integration
      private static readonly double[] k15t_ = { 0.000000000000000, 0.207784955007898, 0.405845151377397, 0.586087235467691, 0.741531185599394, 0.864864423359769, 0.949107912342758, 0.991455371120813 };
      public static double[] k15t { get { return k15t_; } }
}

	//! Integral of a 1-dimensional function using the Gauss-Kronrod methods
//    ! This class provide a non-adaptive integration procedure which
//        uses fixed Gauss-Kronrod abscissae to sample the integrand at
//        a maximum of 87 points.  It is provided for fast integration
//        of smooth functions.
//
//        This function applies the Gauss-Kronrod 10-point, 21-point, 43-point
//        and 87-point integration rules in succession until an estimate of the
//        integral of f over (a, b) is achieved within the desired absolute and
//        relative error limits, epsabs and epsrel. The function returns the
//        final approximation, result, an estimate of the absolute error,
//        abserr and the number of function evaluations used, neval. The
//        Gauss-Kronrod rules are designed in such a way that each rule uses
//        all the results of its predecessors, in order to minimize the total
//        number of function evaluations.
//    
	public class GaussKronrodNonAdaptive : Integrator
	{
		public GaussKronrodNonAdaptive(double absoluteAccuracy, int maxEvaluations, double relativeAccuracy) : base(absoluteAccuracy, maxEvaluations)
		{
			relativeAccuracy_ = relativeAccuracy;
		}
		public double relativeAccuracy()
		{
			return relativeAccuracy_;
		}
		protected override double integrate(Func<double, double> f, double a, double b)
		{
			double result;
			double[] fv1 = new double[5];
			double[] fv2 = new double[5];
			double[] fv3 = new double[5];
			double[] fv4 = new double[5];
			double[] savfun = new double[21]; // array of function values which have been computed 
			double res10; // 10, 21, 43 and 87 point results 
			double res21;
			double res43;
			double res87;
			double err;
			double resAbs; // approximation to the integral of abs(f) 
			double resasc; // approximation to the integral of abs(f-i/(b-a)) 
			int k;
	
			Utils.QL_REQUIRE(a<b,()=> "b must be greater than a)");
	
			double halfLength = 0.5 * (b - a);
			double center = 0.5 * (b + a);
			double fCenter = f(center);
	
			// Compute the integral using the 10- and 21-point formula.
	
			res10 = 0;
			res21 = KronrodintegralArrays.w21b[5] * fCenter;
			resAbs = KronrodintegralArrays.w21b[5] * Math.Abs(fCenter);
	
			for (k = 0; k < 5; k++)
			{
				double abscissa = halfLength * KronrodintegralArrays.x1[k];
				double fval1 = f(center + abscissa);
				double fval2 = f(center - abscissa);
				double fval = fval1 + fval2;
				res10 += KronrodintegralArrays.w10[k] * fval;
				res21 += KronrodintegralArrays.w21a[k] * fval;
				resAbs += KronrodintegralArrays.w21a[k] * (Math.Abs(fval1) + Math.Abs(fval2));
				savfun[k] = fval;
				fv1[k] = fval1;
				fv2[k] = fval2;
			}
	
			for (k = 0; k < 5; k++)
			{
				double abscissa = halfLength * KronrodintegralArrays.x2[k];
				double fval1 = f(center + abscissa);
				double fval2 = f(center - abscissa);
				double fval = fval1 + fval2;
				res21 += KronrodintegralArrays.w21b[k] * fval;
				resAbs += KronrodintegralArrays.w21b[k] * (Math.Abs(fval1) + Math.Abs(fval2));
				savfun[k + 5] = fval;
				fv3[k] = fval1;
				fv4[k] = fval2;
			}
	
			result = res21 * halfLength;
			resAbs *= halfLength;
			double mean = 0.5 * res21;
			resasc = KronrodintegralArrays.w21b[5] * Math.Abs(fCenter - mean);
	
			for (k = 0; k < 5; k++)
				resasc += (KronrodintegralArrays.w21a[k] * (Math.Abs(fv1[k] - mean) + Math.Abs(fv2[k] - mean)) + KronrodintegralArrays.w21b[k] * (Math.Abs(fv3[k] - mean) + Math.Abs(fv4[k] - mean)));
	
			err = KronrodintegralArrays.rescaleError ((res21 - res10) * halfLength, resAbs, resasc);
			resasc *= halfLength;
	
			// test for convergence.
			if (err < absoluteAccuracy() || err < relativeAccuracy() * Math.Abs(result))
			{
				setAbsoluteError(err);
				setNumberOfEvaluations(21);
				return result;
			}
	
			// compute the integral using the 43-point formula. 
	
			res43 = KronrodintegralArrays.w43b[11] * fCenter;
	
			for (k = 0; k < 10; k++)
				res43 += savfun[k] * KronrodintegralArrays.w43a[k];
	
			for (k = 0; k < 11; k++)
			{
				double abscissa = halfLength * KronrodintegralArrays.x3[k];
				double fval = (f(center + abscissa) + f(center - abscissa));
				res43 += fval * KronrodintegralArrays.w43b[k];
				savfun[k + 10] = fval;
				}
	
			// test for convergence.
	
			result = res43 * halfLength;
			err = KronrodintegralArrays.rescaleError ((res43 - res21) * halfLength, resAbs, resasc);
	
		   if (err < absoluteAccuracy() || err < relativeAccuracy() * Math.Abs(result))
		   {
				setAbsoluteError(err);
				setNumberOfEvaluations(43);
				return result;
			}
	
			// compute the integral using the 87-point formula. 
	
			res87 = KronrodintegralArrays.w87b[22] * fCenter;
	
			for (k = 0; k < 21; k++)
				res87 += savfun[k] * KronrodintegralArrays.w87a[k];
	
			for (k = 0; k < 22; k++)
			{
				double abscissa = halfLength * KronrodintegralArrays.x4[k];
				res87 += KronrodintegralArrays.w87b[k] * (f(center + abscissa) + f(center - abscissa));
			}
	
			// test for convergence.
			result = res87 * halfLength;
			err = KronrodintegralArrays.rescaleError ((res87 - res43) * halfLength, resAbs, resasc);
	
			setAbsoluteError(err);
			setNumberOfEvaluations(87);
			return result;
		}
		private double relativeAccuracy_;
	}

	//! Integral of a 1-dimensional function using the Gauss-Kronrod methods
//    ! This class provide an adaptive integration procedure using 15
//        points Gauss-Kronrod integration rule.  This is more robust in
//        that it allows to integrate less smooth functions (though
//        singular functions should be integrated using dedicated
//        algorithms) but less efficient beacuse it does not reuse
//        precedently computed points during computation steps.
//
//        References:
//
//        Gauss-Kronrod Integration
//        <http://mathcssun1.emporia.edu/~oneilcat/ExperimentApplet3/ExperimentApplet3.html>
//
//        NMS - Numerical Analysis Library
//        <http://www.math.iastate.edu/burkardt/f_src/nms/nms.html>
//
//        \test the correctness of the result is tested by checking it
//              against known good values.
//    
	public class GaussKronrodAdaptive : Integrator
	{
		  public GaussKronrodAdaptive(double absoluteAccuracy, int maxEvaluations) : base(absoluteAccuracy, maxEvaluations)
		  {
           Utils.QL_REQUIRE(maxEvaluations >= 15,()=> 
              "required maxEvaluations (" + maxEvaluations + ") not allowed. It must be >= 15");
		  }
          protected override double integrate(Func<double, double> f, double a, double b)
		  {
			  return integrateRecursively(f, a, b, absoluteAccuracy().GetValueOrDefault());
		  }
		  private double integrateRecursively(Func<double, double> f, double a, double b, double tolerance)
		  {
	  
				  double halflength = (b - a) / 2;
				  double center = (a + b) / 2;
	  
				  double g7; // will be result of G7 integral
				  double k15; // will be result of K15 integral
	  
				  double t; // t (abscissa) and f(t)
				  double fsum;
				  double fc = f(center);
				  g7 = fc * KronrodintegralArrays.g7w[0];
				  k15 = fc * KronrodintegralArrays.k15w[0];
	  
				  // calculate g7 and half of k15
				  int j;
				  int j2;
				  for (j = 1, j2 = 2; j < 4; j++, j2 += 2)
				  {
					  t = halflength * KronrodintegralArrays.k15t[j2];
					  fsum = f(center - t) + f(center + t);
					  g7 += fsum * KronrodintegralArrays.g7w[j];
					  k15 += fsum * KronrodintegralArrays.k15w[j2];
				  }
	  
				  // calculate other half of k15
				  for (j2 = 1; j2 < 8; j2 += 2)
				  {
					  t = halflength * KronrodintegralArrays.k15t[j2];
					  fsum = f(center - t) + f(center + t);
					  k15 += fsum * KronrodintegralArrays.k15w[j2];
				  }
	  
				  // multiply by (a - b) / 2
				  g7 = halflength * g7;
				  k15 = halflength * k15;
	  
				  // 15 more function evaluations have been used
				  increaseNumberOfEvaluations(15);
	  
				  // error is <= k15 - g7
				  // if error is larger than tolerance then split the interval
				  // in two and integrate recursively
				  if (Math.Abs(k15 - g7) < tolerance)
				  {
					  return k15;
				  }
				  else
				  {
                 Utils.QL_REQUIRE(numberOfEvaluations() + 30 <= maxEvaluations(),()=> 
                    "maximum number of function evaluations " + "exceeded");
					  return integrateRecursively(f, a, center, tolerance/2) + integrateRecursively(f, center, b, tolerance/2);
				  }
			  }
	  }
}

import UnityEngine
static class SQUAD (): 	
	// Returns a smoothed quaternion along the set of quaternions making up the spline, each quaternion is along an equidistant value in t
	def Spline(quaternions as (Quaternion), t as single):
		section as int = (quaternions.Length-1) * t
		alongLine as single = (quaternions.Length-1) * t - section
		if section == 0:
			return SplineSegment(quaternions[section], quaternions[section], quaternions[section+1], quaternions[section+2], alongLine)
		elif section == quaternions.Length - 2 and section > 0:
			return SplineSegment(quaternions[section-1], quaternions[section], quaternions[section+1], quaternions[section+1], alongLine)
		elif section >= 1 and section < quaternions.Length - 2:
			return SplineSegment(quaternions[section-1], quaternions[section], quaternions[section+1], quaternions[section+2], alongLine)

	// Returns a quaternion between q1 and q2 as part of a smooth SQUAD segment
	def SplineSegment(q0 as Quaternion, q1 as Quaternion, q2 as Quaternion, q3 as Quaternion, t as single):
		qa as Quaternion = Intermediate(q0,q1,q2)
		qb as Quaternion = Intermediate(q1,q2,q3)
		return SQUAD(q1, qa, qb, q2, t)

	// Tries to compute sensible tangent values for the quaternion
	def Intermediate(q0 as Quaternion, q1 as Quaternion, q2 as Quaternion):
		q1inv as Quaternion = Quaternion.Inverse(q1)
		c1 as Quaternion = q1inv * q2 
		c2 as Quaternion = q1inv * q0
		c1.Log()
		c2.Log()
		c3 as Quaternion = c2 + c1
		c3.Scale(-0.25)
		c3.Exp()
		r as Quaternion = q1 * c3 
		r.Normalize()
		return r

	// Returns a smooth approximation between q1 and q2 using t1 and t2 as 'tangents'
	def SQUAD(q1 as Quaternion, t1 as Quaternion, t2 as Quaternion, q2 as Quaternion, t as single):
		slerpT as single = 2.0 * t * (1.0 - t)
		slerp1 as Quaternion = QuaternionExtensions.SlerpNoInvert(q1, q2, t)
		slerp2 as Quaternion = QuaternionExtensions.SlerpNoInvert(t1, t2, t)
		return QuaternionExtensions.SlerpNoInvert(slerp1, slerp2, slerpT) 

	

	
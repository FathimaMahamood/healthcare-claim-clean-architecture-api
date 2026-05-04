from fastapi import FastAPI
from pydantic import BaseModel

# Create app
app = FastAPI()

# =========================
# STEP 1: Request Model
# =========================
class ClaimRequest(BaseModel):
    claimAmount: float
    patientAge: int
    hasInsurance: bool


# =========================
# STEP 2: Test API
# =========================
@app.get("/")
def root():
    return {"message": "AI Risk Service Running"}


# =========================
# STEP 3: Risk Logic API
# =========================
@app.post("/analyze")
def analyze_risk(request: ClaimRequest):

    risk_score = 0

    # Rule 1: High claim amount
    if request.claimAmount > 10000:
        risk_score += 50

    # Rule 2: Elderly patient
    if request.patientAge > 60:
        risk_score += 20

    # Rule 3: No insurance
    if not request.hasInsurance:
        risk_score += 30

    # Final decision
    if risk_score >= 70:
        risk = "HIGH"
    elif risk_score >= 40:
        risk = "MEDIUM"
    else:
        risk = "LOW"

    return {
        "riskScore": risk_score,
        "riskLevel": risk
    }

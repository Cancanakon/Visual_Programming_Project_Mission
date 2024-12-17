import torch
from transformers import AutoTokenizer, AutoModelForCausalLM
from fastapi import FastAPI, HTTPException
from pydantic import BaseModel

model_path = "./turkish-lawyer-model"
device = "cuda" if torch.cuda.is_available() else "cpu"

tokenizer = AutoTokenizer.from_pretrained(model_path)
model = AutoModelForCausalLM.from_pretrained(model_path).to(device)

app = FastAPI(title="Avukat AI API", version="1.0", description="Türkçe hukuk modeli API hizmeti")


class QueryRequest(BaseModel):
    question: str


@app.post("/ask/")
def generate_response(request: QueryRequest):

    try:
        formatted_input = f"Soru: {request.question}\nCevap:"
        inputs = tokenizer.encode(formatted_input, return_tensors="pt").to(device)
        outputs = model.generate(
            inputs,
            max_length=50,
            num_return_sequences=1,
            do_sample=True,
            top_p=0.95,
            temperature=0.8,
            num_beams=3,
            early_stopping=True
        )
        response = tokenizer.decode(outputs[0], skip_special_tokens=True).strip()

        # Boş yanıt kontrolü
        if not response or response.startswith("Cevap:"):
            response = "Bu konuda size yardımcı olamıyorum, lütfen daha detaylı bir soru sorun."

        return {"response": response}
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))


@app.get("/")
def read_root():
    return {"message": "Avukat AI API'ye hoş geldiniz! POST /ask endpointi ile sorularınızı sorabilirsiniz."}

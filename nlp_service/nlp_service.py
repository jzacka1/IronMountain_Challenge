from fastapi import FastAPI
import spacy

app = FastAPI()
nlp = spacy.load("en_core_web_sm")


# Very simple rule engine for demo
def parse_query(text):
    doc = nlp(text.lower())
    
    filters = {}

    # detect age
    for token in doc:
        if token.like_num:
            age = int(token.text)
            if "older" in text or "greater" in text:
                filters["AgeMin"] = age
            elif "younger" in text or "less" in text:
                filters["AgeMax"] = age

    # detect name search
    for ent in doc.ents:
        if ent.label_ == "PERSON":
            filters["NameContains"] = ent.text

    return filters


@app.post("/parse")
async def parse(request: dict):
    text = request.get("query", "")
    result = parse_query(text)
    return {"filters": result}

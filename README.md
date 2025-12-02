# HAZEL — A Context-Aware Mixed Reality Voice Assistant

## MADE FOR MIXED REALITY WEARABLES LIKE META RAY BAN GLASSES AND META OCULUS

HAZEL is an intelligent voice-driven mixed reality assistant capable of understanding your environment, responding conversationally, and generating realistic speech in real time. Think JARVIS inside MR — aware of surroundings, answering questions, narrating insights, guiding actions, and interacting naturally.

---

## ✨ Core Features

### 🔹 Spatial Understanding
- Continuously scans and interprets the user's environment
- Recognizes surfaces, objects, markers, or scene elements
- Users can ask questions about visible surroundings
- Extensible into overlay guidance and contextual MR workflows

### 🔹 Push-to-Talk Conversational Interaction
- A simple button press activates voice listening
- Speak naturally after activation
- Responds intelligently using scene awareness + general reasoning
- Maintains dialogue flow across follow-up questions

### 🔹 Real-Time Voice Output with Murf Falcon TTS
- Produces natural-sounding responses immediately using **Murf Falcon TTS**
- High-quality, human-like voice synthesis
- Enables smooth, immersive, human-like communication
- Customizable voice parameters (pitch, speed, speaker selection)

### 🔹 Hands-Free Playback
- Once activated via button, interaction is spoken end-to-end
- No typing or UI navigation required
- Ideal for accessibility, spatial guidance, and task automation

### 🔹 Secure API Usage
- API keys handled through environment variables
- Clean separation between codebase and credentials
- No hardcoded secrets in repository

---

## 🧠 Architecture Overview

```
Environment Scanner  →  Scene Context Engine  
        ↓                          ↓
Push-to-Talk Input → Speech Recognition → AI Reasoning → Voice Synthesis (Murf Falcon TTS) → Audio Output
```

**Scene perception + spoken query = grounded, contextual intelligent answers.**

---

## 🔍 Vision + Voice Reasoning Pipeline

### 🧠 OpenAI Vision Model Integration

**Purpose:** Query a multi-modal LLM (Vision + Language) for contextual reasoning of the current scene.

#### How It Works:

**1. Speech Input → Command String**
- User triggers input via push-to-talk
- Microphone audio is captured and sent to OpenAI Speech-to-Text (ASR)
- The resulting text becomes the query instruction for the vision model

**2. Scene Capture → Screenshot Feed**
- A camera feed (Unity render texture / mixed reality viewport capture) is captured
- The frame is serialized and attached as a binary payload to the vision request

**3. Multi-Modal LLM Request**
- The system sends a combined payload:
  - Command text (intent/question)
  - Scene image (snapshot)
  - Optional additional prompting context
- Supported request modes:
  - Text-only
  - Image-only
  - Image + Command Text hybrid reasoning

**4. Inference (Vision Model Reasoning)**
- The model returns structured natural-language output containing:
  - Object recognition
  - Affordance suggestions
  - Spatial descriptions
  - Task answers
  - Conversational reasoning
- End-to-end round-trip typically runs 2–6 seconds, depending on network conditions

**5. Speech Output (Murf Falcon TTS Synthesis)**
- The returned text is routed to **Murf Falcon TTS** for voice generation
- High-quality, natural-sounding speech synthesis
- The result is streamed into Unity's audio playback system
- The user hears the answer spoken aloud

---

## ⚙️ Configurable Parameters

The system supports runtime adjustments for:

- **Speaker voice selection** (via Murf Falcon TTS)
- **Speech pitch and playback speed**
- **Model selection** (different OpenAI vision/language model variants)
- **Prompt modifiers:**
  - Task framing
  - System instructions
  - Domain-specific guidance

Developers can dynamically modify the model's behavior by changing prompt templates and image pairing strategies.

---

## 📌 Technology Stack

- ✔ **Unity** — Mixed reality application platform
- ✔ **Spatial mapping and perception components**
- ✔ **Push-to-talk speech recognition**
- ✔ **OpenAI Vision API** — Multi-modal AI reasoning
- ✔ **OpenAI Speech-to-Text (Whisper)** — Voice input processing
- ✔ **Murf Falcon TTS** — Natural voice synthesis
- ✔ **Dialogue and perception intelligence system**

---

## 🌍 Possible Applications

HAZEL can evolve into:

- ✔ Mixed Reality assistant
- ✔ Guided exploration companion
- ✔ Smart classroom/tutorial agent
- ✔ Interactive environment narrator
- ✔ Voice-based productivity tool
- ✔ Accessibility support and narration aid

---

## 🎯 Why Mixed Reality + Push-to-Talk Voice?

- **Voice enables natural communication**
- **Button triggering ensures intentional interaction**
- **MR context increases relevance of answers**
- **Makes digital assistance physically present in your space**

---

## 📢 Inspiration

A step toward **JARVIS-like ambient intelligence** — an assistant that listens when called, understands space, and responds meaningfully.

---

## 🚀 Getting Started

### Prerequisites
- Unity 2021.3 or later
- OpenAI API key
- Murf Falcon TTS API access
- Mixed Reality headset (Quest, HoloLens, etc.)

### Setup
1. Clone the repository
2. Configure environment variables for API keys:
   ```bash
   OPENAI_API_KEY=your_openai_key
   MURF_API_KEY=your_murf_key
   ```
3. Open project in Unity
4. Deploy to your MR device
5. Press the push-to-talk button and start conversing!
---



---

**Built with ❤️ for the future of spatial computing*

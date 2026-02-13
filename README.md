
HAZEL — A Context-Aware Mixed Reality Voice Assistant
WITH AI 3D CHATBOT & AI-GENERATED EDUCATIONAL VIDEO ENGINE
MADE FOR MIXED REALITY WEARABLES LIKE META RAY-BAN GLASSES AND META QUEST / OCULUS

HAZEL is an intelligent, context-aware Mixed Reality assistant that exists as a 3D AI avatar inside your physical space. It understands your surroundings, responds conversationally using voice, generates interactive 3D content, and creates personalized AI-generated educational videos in real time.

Think JARVIS inside Mixed Reality — aware of your environment, embodied as a 3D chatbot, answering questions, narrating insights, generating visuals, and guiding actions naturally.



✨ Core Capabilities (High Level)

AI 3D Chatbot Avatar inside Mixed Reality

Context-aware voice assistant with spatial understanding

Real-time environment-aware reasoning (Vision + Language)

AI-generated 3D objects from sketches / ideas

On-demand AI-generated educational videos with narration

Natural, real-time voice interaction

✨ Core Features
🔹 AI 3D Chatbot Avatar (Mixed Reality)

HAZEL appears as a 3D embodied assistant in the MR environment

Maintains eye-level spatial presence and conversational continuity

Responds with synchronized voice and spatial awareness

Enhances engagement, trust, and immersion compared to flat voice assistants

🔹 Spatial Understanding

Continuously scans and interprets the user's environment

Recognizes surfaces, objects, markers, or scene elements

Users can ask questions about what they are seeing around them

Extensible into spatial overlays, step-by-step MR guidance, and contextual workflows

🔹 Push-to-Talk Conversational Interaction

Simple button press activates listening

Speak naturally after activation

Maintains conversational context across follow-ups

Prevents accidental triggers while enabling fast interaction

🔹 Real-Time Voice Output (Murf Falcon TTS)

Produces natural, human-like speech in real time

High-quality Murf Falcon TTS voice synthesis

Supports pitch, speed, and speaker customization

Ensures immersive, non-robotic communication

🔹 Hands-Free End-to-End Interaction

Entire interaction is voice-driven after activation

No typing, menus, or UI navigation

Ideal for MR wearables, accessibility, learning, and guidance

🔹 AI-Powered 2D → 3D Content Generation

User sketches, drawings, or concept inputs are converted into interactive 3D models

Generated 3D objects can be:

Rotated

Scaled

Examined spatially

Transforms imagination into tangible learning artifacts

🔹 AI-Generated Educational Videos (On Demand)

Instantly generates personalized educational videos based on:

User questions

Current learning topic

Scene context

Includes:

AI-generated script

Voice narration

Visual sequencing

Created in minutes at a fraction of traditional production cost

🔹 Secure API Usage

API keys managed via environment variables

No hardcoded credentials

Clean separation of secrets and codebase

🧠 Architecture Overview
Environment Scanner → Scene Context Engine
        ↓
Push-to-Talk → Speech-to-Text → Vision + Language Reasoning
        ↓
AI Response → (3D Chatbot + Voice Output)
        ↓
Optional Pipelines:
  → AI 3D Object Generation
  → AI Educational Video Generation


Scene perception + voice + spatial AI = grounded, intelligent responses.

🔍 Vision + Voice Reasoning Pipeline
🧠 OpenAI Multi-Modal Model Integration

Purpose:
Enable contextual reasoning using vision + language + voice.

How It Works:

1. Voice Input

Push-to-talk captures microphone audio

Audio sent to OpenAI Speech-to-Text (Whisper)

Transcribed text becomes the reasoning prompt

2. Scene Capture

Unity MR camera frame or render texture captured

Scene image serialized and attached to request

3. Multi-Modal LLM Request

Payload includes:

Command text

Scene image

System + task prompt

Supports:

Text-only reasoning

Image-only reasoning

Hybrid image + text reasoning

4. AI Inference

Model outputs:

Object recognition

Spatial descriptions

Concept explanations

Task guidance

Typical latency: 2–6 seconds

5. Voice Synthesis

Output routed to Murf Falcon TTS

Generated speech streamed into Unity audio system

User hears contextual response instantly

⚙️ Configurable Parameters

3D chatbot behavior & tone

Voice selection, pitch, speed

Model selection (vision / language variants)

Prompt templates & domain specialization

Video generation depth and narration style

📌 Technology Stack

Unity (Mixed Reality application layer)

Spatial Mapping & Perception Systems

OpenAI Vision + Language Models

OpenAI Speech-to-Text (Whisper)

Murf Falcon TTS

AI 2D-to-3D Generation Pipelines

AI Educational Video Generation Pipeline

🌍 Possible Applications

Mixed Reality AI assistant

AI-powered smart classroom companion

Interactive learning & tutoring agent

Environment-aware narrator

Hands-free productivity assistant

Accessibility and assistive technology

🎯 Why Mixed Reality + 3D AI + Voice?

Voice is the most natural interface

3D embodiment increases trust and engagement

Spatial context improves relevance

Learning becomes immersive, not passive

📢 Inspiration

A step toward JARVIS-like ambient intelligence —
an assistant that listens when called, understands space, exists physically as a 3D presence, and responds meaningfully.

🚀 Getting Started
Prerequisites

Unity 2021.3 or later

OpenAI API key

Murf Falcon TTS API access

Mixed Reality headset (Quest, HoloLens, Ray-Ban Meta, etc.)

Setup
OPENAI_API_KEY=your_openai_key
MURF_API_KEY=your_murf_key


Clone repository

Configure environment variables

Open in Unity

Deploy to MR device

Press push-to-talk and start interacting

Built with ❤️ for the future of spatial computing

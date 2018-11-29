--
-- PostgreSQL database dump
--

-- Dumped from database version 11.1
-- Dumped by pg_dump version 11.1

-- Started on 2018-11-28 19:11:18

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 197 (class 1259 OID 16406)
-- Name: epic; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.epic (
    id integer,
    epic character varying,
    description character varying,
    category character varying,
    subcategory character varying
);


ALTER TABLE public.epic OWNER TO postgres;

--
-- TOC entry 196 (class 1259 OID 16400)
-- Name: goalcandidates; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.goalcandidates (
    goalcandidate integer,
    description character varying,
    importance integer,
    deliverabledate date,
    goalid integer,
    epicid integer,
    taskid integer,
    id integer
);


ALTER TABLE public.goalcandidates OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 16420)
-- Name: goals; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.goals (
    id integer NOT NULL,
    epicid integer,
    goalcandidateid integer,
    goal character varying,
    description character varying,
    ranking integer,
    deliverabledate date,
    isspecific boolean,
    ismeasureable boolean,
    isachieveable boolean,
    isrelevant boolean,
    istimebound boolean
);


ALTER TABLE public.goals OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 16418)
-- Name: goals_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.goals_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.goals_id_seq OWNER TO postgres;

--
-- TOC entry 2833 (class 0 OID 0)
-- Dependencies: 199
-- Name: goals_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.goals_id_seq OWNED BY public.goals.id;


--
-- TOC entry 198 (class 1259 OID 16412)
-- Name: tasks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tasks (
    id integer,
    task character varying,
    description character varying,
    rank integer,
    deadline date,
    category character varying,
    subcategory character varying,
    goalsid integer
);


ALTER TABLE public.tasks OWNER TO postgres;

--
-- TOC entry 2701 (class 2604 OID 16423)
-- Name: goals id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.goals ALTER COLUMN id SET DEFAULT nextval('public.goals_id_seq'::regclass);


--
-- TOC entry 2824 (class 0 OID 16406)
-- Dependencies: 197
-- Data for Name: epic; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.epic (id, epic, description, category, subcategory) FROM stdin;
\.


--
-- TOC entry 2823 (class 0 OID 16400)
-- Dependencies: 196
-- Data for Name: goalcandidates; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.goalcandidates (goalcandidate, description, importance, deliverabledate, goalid, epicid, taskid, id) FROM stdin;
\.


--
-- TOC entry 2827 (class 0 OID 16420)
-- Dependencies: 200
-- Data for Name: goals; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.goals (id, epicid, goalcandidateid, goal, description, ranking, deliverabledate, isspecific, ismeasureable, isachieveable, isrelevant, istimebound) FROM stdin;
\.


--
-- TOC entry 2825 (class 0 OID 16412)
-- Dependencies: 198
-- Data for Name: tasks; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tasks (id, task, description, rank, deadline, category, subcategory, goalsid) FROM stdin;
\.


--
-- TOC entry 2834 (class 0 OID 0)
-- Dependencies: 199
-- Name: goals_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.goals_id_seq', 1, false);


-- Completed on 2018-11-28 19:11:19

--
-- PostgreSQL database dump complete
--


create table users
(
	id bigint generated always as identity primary key,
	user_name varchar (50) not null,
	password varchar not null,
	email varchar not null,
	first_name varchar,
	last_name varchar,
	image_path text not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table events 
(
	id bigint generated always as identity primary key,
	event_name varchar not null,
	date_time date,
	location varchar not null,
	description text,
	organizer_id bigint references users (id),
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table event_tickets
(
	id bigint generated always as identity primary key,
	event_id bigint references events (id),
	ticket_name varchar not null,
	price double precision not null,
	quantity_available integer not null,
	sales_start_date date not null,
	sales_end_date date not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table event_registration
(
	id bigint generated always as identity primary key,
	event_id bigint references events (id),
	attendee_id bigint references users (id),
	numberof_tickets bigint not null,
	total_price decimal not null,
	registration_date date not null,
	payment_status bool not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table comments
(
	id bigint generated always as identity primary key,
	event_id bigint references events (id),
	author_id bigint references users (id),
	content text not null,
	time_stamp date not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table notifications
(
	id bigint generated always as identity primary key,
	recipient_id bigint references users (id),
	content text not null,
	time_stamp date not null,
	is_read bool,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);
SET TIMEZONE TO 'UTC';
